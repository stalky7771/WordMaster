using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
	public static VocabularyManager VocabularyManager { get; private set; }

	private static readonly List<BaseManager> _managers = new List<BaseManager>();

	private void Awake()
    {
		Init();

		_managers.ForEach(m => m.InitAwake());
	}

	private void Start()
	{
		_managers.ForEach(m => m.InitStart());
	}

	private void Init()
	{
		Application.targetFrameRate = 60;

		_managers.Add(VocabularyManager = new VocabularyManager());
	}
}
