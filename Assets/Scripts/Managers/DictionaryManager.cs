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

			LoadDictionary(fileName);
		}

		public void SaveDictionary()
		{
			_dictionary.Save(_dictionary.FileName);
		}

		public void LoadDictionary(string fileName)
        {
			_dictionary = new Dictionary();
			_dictionary.Load(fileName);

            Context.Config.LastDictionaryFilePath = fileName;

			StartWorkWithDictionary(_dictionary);
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
						SaveDictionary();
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

        public void ResetProgress()
        {
			if (_dictionary == null)
				return;

			_dictionary.ResetProgress();
            StartWorkWithDictionary(_dictionary);
        }

        private void UpdateWordChecker()
        {
            InputWord(_lastEnteredText);
        }

        private void StartWorkWithDictionary(Dictionary dictionary)
        {
            OnPrintDictionary?.Invoke(dictionary);

            if (dictionary.IsEmpty)
            {
                OnDictionaryFinished?.Invoke(true);
                return;
            }

            OnDictionaryFinished?.Invoke(false);

            CurrentWord = dictionary.NextWord;

            if (CurrentWord == null)
            {
                OnDictionaryFinished?.Invoke(true);
                return;
            }

            InputWord(string.Empty);
            OnSetNewWord?.Invoke(CurrentWord);
            OnUpdateUi?.Invoke();
			OnPrintDictionary?.Invoke(_dictionary);

            _wordViewCounter = 0;
		}
	}
}