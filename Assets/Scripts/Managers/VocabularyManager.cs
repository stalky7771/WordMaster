using System.IO;
using UnityEngine;

public class VocabularyManager : BaseManager
{
	private string PATH_CSV = @"C:\_DATA\_Projects\WordMaster\Assets\Dicts\Dictionary.csv";

	private Vocabulary _vocabulary;

	public Vocabulary Vocabulary => _vocabulary;

	public override void Init()
	{
		_vocabulary = new Vocabulary();

		LoadFromJson();
		//GenerateDefaultVocabulary(_vocabulary);
		//Load();

		base.Init();
	}

	public string PathJson => Application.persistentDataPath + "/dictionary.json";

	public void LoadFromCSV()
	{
		_vocabulary.LoadFromCSV(PATH_CSV);
	}

	public void SaveToJson()
	{
		//_vocabulary.SetDefaultData();

		string json = JsonUtility.ToJson(new VocabularyDTO(_vocabulary), true);
		File.WriteAllText(PathJson, json);
	}

	public void LoadFromJson()
	{
		_vocabulary.LoadFromJson(PathJson);
		Context.InputManager.UpdateWord();
	}
}
