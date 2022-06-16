using System;
using System.IO;
using UnityEngine;

namespace WordMaster
{
	public class DictionaryManager : BaseManager
	{
		public event Action OnUpdateUi;
		public event Action OnDictionaryFinished;
		public event Action<WordItem> OnSetNewWord;
		public event Action<WordItem> OnWordFinished;
		public event Action<Dictionary> OnPrintDictionary;

		private Dictionary _dictionary;
		public Dictionary Dictionary => _dictionary;

		public string Masked { get; private set; }
		//public string FileName => Application.persistentDataPath + "/dictionary.voc";

		private string _lastEnteredText;

		public WordItem CurrentWord { get; private set; }

		public override void InitAwake()
		{
			_dictionary = new Dictionary();
			base.InitAwake();
		}

		public override void InitStart()
		{
			Context.Options.OnUpdate += Update;

			var fileName = Context.Options.DictionaryFileName;

			if (string.IsNullOrEmpty(fileName))
				fileName = @"D:\DOWNLOAD\L15.dict";

			LoadFromJson(fileName);
		}

		public void SaveToJson()
		{
			string json = JsonUtility.ToJson(new DictionaryDTO(_dictionary), true);
			File.WriteAllText(_dictionary.FileName, json);
		}

		public void LoadFromJson(string fileName)
		{
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
		}

		public void Update()
		{
			InputWord(_lastEnteredText);
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
					CurrentWord.AnswerCorrect();
					OnWordFinished?.Invoke(CurrentWord);
					CurrentWord = Dictionary.NextWord;

					OnPrintDictionary?.Invoke(Dictionary);

					if (CurrentWord == null)
					{
						OnDictionaryFinished?.Invoke();
						return;
					}

					OnSetNewWord?.Invoke(CurrentWord);
					return;
				}
			}
			else
			{
				var phrase = CurrentWord.Word;
				Masked = Context.Options.ShowCorrectWord || isEndEdit
					? phrase.SetColor("red")
					: CurrentWord.GetMaskedText(text, isReversed).SetColor("red");

				CurrentWord.AnswerWrong();
			}

			OnPrintDictionary?.Invoke(Dictionary);
			OnUpdateUi?.Invoke();
		}

		public void RemoveCurrentWord()
		{
			_dictionary.DeleteWord(CurrentWord);
			CurrentWord = Dictionary.NextWord;
			OnSetNewWord?.Invoke(CurrentWord);
			OnPrintDictionary?.Invoke(Dictionary);
		}
	}
}