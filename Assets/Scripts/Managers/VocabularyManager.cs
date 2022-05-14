using System;
using System.IO;
using UnityEngine;

public class VocabularyManager : BaseManager
{
	private string PATH_CSV = @"C:\_DATA\_Projects\WordMaster\Assets\Dicts\Dictionary.csv";

	public event Action OnUpdateUi;
	public event Action<WordItem> OnSetNewWord;
	public event Action<WordItem> OnWordFinished;
	public event Action<Vocabulary> OnPrintVocabulary;

	private Vocabulary _vocabulary;
	public Vocabulary Vocabulary => _vocabulary;

	public string Masked { get; private set; }
	public string PathJson => Application.persistentDataPath + "/dictionary.json";

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
		CurrentWord = Vocabulary.NextWord;
		OnSetNewWord?.Invoke(CurrentWord);
	}

	public void SetDefaultVacabulary()
	{
		_vocabulary.SetDefaultData();
		CurrentWord = Vocabulary.NextWord;
		OnSetNewWord?.Invoke(CurrentWord);
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

	public void ProcessWord(string text)
	{
		bool isReversed = Options.IsReversed;

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
			string phrase = CurrentWord.GetWord(isReversed);
			Masked = phrase.SetColor("red");
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
