using System;
using System.IO;
using Assets.Scripts.Utils;
using UnityEngine;

namespace WordMaster
{
	public class DictionaryManager : BaseManager
	{
		public event Action OnUpdateUi;
		public event Action OnDictionaryFinished;
		public event Action OnSaveDictionary;
		public event Action<Word> OnSetNewWord;
		public event Action<Word> OnWordFinished;
		public event Action<Dictionary> OnPrintDictionary;

		private Dictionary _dictionary;
		public Dictionary Dictionary => _dictionary;

		public string Masked { get; private set; }

		private string _lastEnteredText;

		public Word CurrentWord { get; private set; }
		public StatisticsHelper Statistics { get; private set; }

		private int _wordViewCounter;

		public override void InitAwake()
		{
			_dictionary = new Dictionary();
			base.InitAwake();
		}

		public override void InitStart()
		{
			Statistics = new StatisticsHelper();

			Context.Options.OnUpdate += UpdateWordChecker;

			var fileName = Context.Options.DictionaryFileName;

			if (string.IsNullOrEmpty(fileName))
				fileName = @"D:\_RESEARCH\UNITY\Dictionaries\L15.dict";

			LoadFromJson(fileName);
		}

		public void SaveToJson()
		{
			string json = JsonUtility.ToJson(new DictionaryDto(_dictionary), true);
			File.WriteAllText(_dictionary.FileName, json);
			_wordViewCounter = 0;
		}

		public void LoadFromJson(string fileName)
		{
			Statistics.Clear();
			
			_dictionary.LoadFromJson(fileName);
			Context.Options.DictionaryFileName = fileName;
			OnPrintDictionary?.Invoke(_dictionary);

			if (_dictionary.IsEmpty)
			{
				OnDictionaryFinished?.Invoke();
				return;
			}

			CurrentWord = Dictionary.NextWord;

			if (CurrentWord == null)
			{
				OnDictionaryFinished?.Invoke();
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

		public void InputWord(string text, bool isEndEdit = false)
		{
			var isReversed = Context.Options.IsReversed;

			_lastEnteredText = text;

			if (CurrentWord == null)
			{
				OnDictionaryFinished?.Invoke();
				return;
			}

			var isCorrectWord = CurrentWord.IsCorrectTranslation(text, isReversed);

			if (isEndEdit)
			{
				isCorrectWord &= CurrentWord.IsTranslateFinished(text, isReversed);
			}

			if (isCorrectWord)
			{
				Masked = CurrentWord.GetMaskedText(text, isReversed).SetColor("white");

				if (CurrentWord.IsFullTranslation(text, isReversed))
				{
					Statistics.IncrementCorrectAnswer();
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
						OnDictionaryFinished?.Invoke();
						return;
					}

					OnSetNewWord?.Invoke(CurrentWord);
					OnUpdateUi?.Invoke();
					return;
				}
			}
			else
			{
				var phrase = CurrentWord.Value;
				Masked = Context.Options.ShowCorrectWord || isEndEdit
					? phrase.SetColor("red")
					: CurrentWord.GetMaskedText(text, isReversed).SetColor("red");

				CurrentWord.AnswerWrong();
				Statistics.IncrementWrongAnswer();
			}

			OnPrintDictionary?.Invoke(Dictionary);
			OnUpdateUi?.Invoke();
		}

		public void RemoveCurrentWord()
		{
			_dictionary.RemoveWord(CurrentWord);
			CurrentWord = Dictionary.NextWord;
			OnSetNewWord?.Invoke(CurrentWord);
			OnPrintDictionary?.Invoke(Dictionary);
		}

		public void PrintDictionary()
		{
			OnPrintDictionary?.Invoke(Dictionary);
		}
	}
}