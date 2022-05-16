using System;
using System.IO;
using UnityEngine;

namespace WordMaster
{
	public class VocabularyManager : BaseManager
	{
		//private string PATH_CSV = @"C:\_DATA\_Projects\WordMaster\Assets\Dicts\Dictionary.csv";

		public event Action OnUpdateUi;
		public event Action<WordItem> OnSetNewWord;
		public event Action<WordItem> OnWordFinished;
		public event Action<Vocabulary> OnPrintVocabulary;

		private Vocabulary _vocabulary;
		public Vocabulary Vocabulary => _vocabulary;

		public string Masked { get; private set; }
		public string PathJson => Application.persistentDataPath + "/dictionary.voc";

		private string _lastEnteredText;

		private WordItem _currentWord;
		public WordItem CurrentWord
		{
			get { return _currentWord ??= WordItem.EmptyWord; }
			private set => _currentWord = value;
		}

		public override void InitAwake()
		{
			_vocabulary = new Vocabulary();
			base.InitAwake();
		}

		public override void InitStart()
		{
			LoadFromJson();

			if (_vocabulary.IsEmpty)
			{
				_vocabulary.SetDefaultData();
			}
			CurrentWord = Vocabulary.NextWord;
			ProcessWord(string.Empty);
			OnSetNewWord?.Invoke(CurrentWord);

			Context.Options.OnUpdate += Update;
		}

		/*public void LoadFromCSV()
		{
			_vocabulary.LoadFromCSV(PATH_CSV);
		}*/

		public void SaveToJson()
		{
			//_vocabulary.SetDefaultData();

			string json = JsonUtility.ToJson(new VocabularyDTO(_vocabulary), true);
			File.WriteAllText(PathJson, json);
		}

		public void LoadFromJson()
		{
			_vocabulary.LoadFromJson(PathJson);
		}

		public void Update()
		{
			ProcessWord(_lastEnteredText);
		}

		public void ProcessWord(string text)
		{
			bool isReversed = Context.Options.IsReversed;

			_lastEnteredText = text;

			if (CurrentWord.IsCorrectTranslation(text, isReversed))
			{
				Masked = CurrentWord.GetMaskedText(text, isReversed).SetColor("white");

				if (CurrentWord.IsFullTranslation(text, isReversed))
				{
					CurrentWord.AnswerCorrect();
					OnWordFinished?.Invoke(CurrentWord);
					CurrentWord = Vocabulary.NextWord;
					OnSetNewWord?.Invoke(CurrentWord);
					OnPrintVocabulary?.Invoke(Vocabulary);
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

			OnPrintVocabulary?.Invoke(Vocabulary);
			OnUpdateUi?.Invoke();
		}

		public void DeleteCurrentWord()
		{
			_vocabulary.DeleteWord(CurrentWord);
			CurrentWord = Vocabulary.NextWord;
			OnSetNewWord?.Invoke(CurrentWord);
			OnPrintVocabulary?.Invoke(Vocabulary);
		}
	}
}