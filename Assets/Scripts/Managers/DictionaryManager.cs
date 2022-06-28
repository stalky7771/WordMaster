using System;
using UnityEngine;

namespace WordMaster
{
	public class DictionaryManager : BaseManager
	{
		public event Action OnUpdateUi;
		public event Action OnSaveDictionary;
		public event Action<bool> OnDictionaryFinished;
		public event Action<Word> OnSetNewWord;
		public event Action<Word> OnWordFinished;
		public event Action<Dictionary> OnPrintDictionary;

		private Dictionary _dictionary;
		public Dictionary Dictionary => _dictionary;

		public string Masked { get; private set; }

		private string _lastEnteredText;

		public Word CurrentWord { get; private set; }

		private int _wordViewCounter;

		public override void InitAwake()
		{
			_dictionary = new Dictionary();
			base.InitAwake();
		}

		public override void InitStart()
		{
			Context.Config.OnUpdate += UpdateWordChecker;

			var fileName = Context.Config.LastDictionaryFilePath;

			if (string.IsNullOrEmpty(fileName))
				fileName = @"D:\_RESEARCH\UNITY\Dictionaries\L15.dict";

			LoadFromJson(fileName);
		}

		public void SaveToJson()
		{
			var json = PersistenceHelper.SaveToJson(new DictionaryDto(_dictionary));
			PersistenceHelper.WriteToFile(_dictionary.FileName, json);
		}

		public void LoadFromJson(string fileName)
        {
            var json = PersistenceHelper.ReadFromFile(fileName);
			var dto = PersistenceHelper.LoadFromJson<DictionaryDto>(json);

			_dictionary = new Dictionary(dto, fileName);

			Context.Config.LastDictionaryFilePath = fileName;
			OnPrintDictionary?.Invoke(_dictionary);

			if (_dictionary.IsEmpty)
			{
				OnDictionaryFinished?.Invoke(true);
				return;
			}

			OnDictionaryFinished?.Invoke(false);

			CurrentWord = Dictionary.NextWord;

			if (CurrentWord == null)
			{
				OnDictionaryFinished?.Invoke(true);
				return;
			}

			InputWord(string.Empty);
			OnSetNewWord?.Invoke(CurrentWord);
			OnUpdateUi?.Invoke();

			_wordViewCounter = 0;
		}

		private void UpdateWordChecker()
		{
			InputWord(_lastEnteredText);
		}

		public override void Update()
		{
			_dictionary?.AddDeltaTime(Time.deltaTime);
		}

		public bool InputWord(string text, bool isEndEdit = false)
		{
			var isReversed = Context.Config.IsReversedWord;
            var showFirstLetter = Context.Config.ShowFirstLetter;
			var result = false;

			_lastEnteredText = text;

			if (CurrentWord == null)
			{
				OnDictionaryFinished?.Invoke(true);
				return false;
			}

			var isCorrectWord = CurrentWord.IsCorrectTranslation(text, isReversed);

			if (isEndEdit)
			{
				isCorrectWord &= CurrentWord.IsTranslateFinished(text, isReversed);
			}

			if (isCorrectWord)
			{
				Masked = CurrentWord.GetMaskedText(text, isReversed, showFirstLetter).SetColor("white");

				if (CurrentWord.IsFullTranslation(text, isReversed))
				{
					Dictionary.Statistics.IncrementCorrectAnswer();
					CurrentWord.AnswerCorrect();
					OnWordFinished?.Invoke(CurrentWord);
					CurrentWord = Dictionary.NextWord;
					_wordViewCounter++;

					if (_wordViewCounter == 3)
					{
						_wordViewCounter = 0;
						SaveToJson();
						OnSaveDictionary?.Invoke();
					}

					OnPrintDictionary?.Invoke(Dictionary);

					if (CurrentWord == null)
					{
						OnDictionaryFinished?.Invoke(true);
						return result;
					}

					OnSetNewWord?.Invoke(CurrentWord);
					OnUpdateUi?.Invoke();
					return result;
				}
			}
			else
			{
				if (isEndEdit == false)
				{
					text = text.Remove(text.Length - 1);
					result = true;
				}

				//var phrase = CurrentWord.Value;
				Masked = Context.Config.ShowCorrectWord && isEndEdit
					? CurrentWord.GetMaskedText(text, isReversed, showFirstLetter, false).SetColor("red") //phrase.SetColor("red")
					: CurrentWord.GetMaskedText(text, isReversed, showFirstLetter).SetColor("red");

				CurrentWord.AnswerWrong();
				Dictionary.Statistics.IncrementWrongAnswer();
			}

			OnPrintDictionary?.Invoke(Dictionary);
			OnUpdateUi?.Invoke();

			return result;
		}

		public void RemoveCurrentWord()
		{
			_dictionary.RemoveWord(CurrentWord);
			CurrentWord = Dictionary.NextWord;
			OnSetNewWord?.Invoke(CurrentWord);
			OnPrintDictionary?.Invoke(Dictionary);
			OnUpdateUi?.Invoke();
		}

		public void PrintDictionary()
		{
			OnPrintDictionary?.Invoke(Dictionary);
		}
	}
}