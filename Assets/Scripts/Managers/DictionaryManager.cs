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
		//public string PathJson => Application.persistentDataPath + "/dictionary.voc";
		public string PathJson => @"D:\DOWNLOAD\111.dict";

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

			LoadFromJson();

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

			ProcessWord(string.Empty);
			OnSetNewWord?.Invoke(CurrentWord);
		}

		public void SaveToJson()
		{
			string json = JsonUtility.ToJson(new DictionaryDTO(_dictionary), true);
			File.WriteAllText(_dictionary.Path, json);
		}

		public void LoadFromJson()
		{
			_dictionary.LoadFromJson(PathJson);
		}

		public void Update()
		{
			ProcessWord(_lastEnteredText);
		}

		public void ProcessWord(string text)
		{
			bool isReversed = Context.Options.IsReversed;

			_lastEnteredText = text;

			if (CurrentWord == null)
			{
				OnDictionaryFinished?.Invoke();
				return;
			}

			if (CurrentWord.IsCorrectTranslation(text, isReversed))
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
				string phrase = CurrentWord.Word;
				Masked = Context.Options.ShowCorrectWord
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