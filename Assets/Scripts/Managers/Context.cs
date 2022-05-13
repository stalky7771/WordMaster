using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
	public static VocabularyManager VocabularyManager { get; private set; }
	public static InputManager InputManager { get; private set; }

	private static readonly List<BaseManager> _managers = new List<BaseManager>();

	private void Awake()
    {
		Init();
	}

	private void Init()
	{
		Application.targetFrameRate = 45;

		_managers.Add(VocabularyManager = new VocabularyManager());
		_managers.Add(InputManager = new InputManager());

		_managers.ForEach(m => m.Init());
	}

	public void OnClickTest()
	{
		Debug.Log(">>> OnClickTest");
	}

	public void OnClickLoadFromCSV()
	{
		VocabularyManager.LoadFromCSV();
	}

	public void OnClickLoadFromJson()
	{
		VocabularyManager.LoadFromJson();
	}

	public void OnClickSaveToJson()
	{
		VocabularyManager.SaveToJson();
	}
}
