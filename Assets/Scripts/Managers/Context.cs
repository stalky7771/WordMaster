using System.Collections.Generic;
using UnityEngine;

namespace WordMaster
{
	public class Context : MonoBehaviour
	{
		public static DictionaryManager DictionaryManager { get; private set; }
		public static FpsManager FpsManager { get; private set; }
		public static GameManager GameManager { get; private set; }
		public static ConfigurationManager Config { get; private set; }

		public static MainView View { get; private set; }

		private readonly List<BaseManager> _managers = new();
		private readonly List<BaseManager> _managersUpdate = new();

		private void Init()
		{
			Application.targetFrameRate = 45;

			_managers.Add(GameManager = new GameManager());
			_managers.Add(DictionaryManager = new DictionaryManager());
			_managers.Add(FpsManager = new FpsManager());
			_managers.Add(Config = new ConfigurationManager());

			_managersUpdate.Add(DictionaryManager);
			_managersUpdate.Add(FpsManager);
		}

		private void Awake()
		{
			Init();
			_managers.ForEach(m => m.InitAwake());
		}

		private void Start()
		{
			_managers.ForEach(m => m.InitStart());
		}

		private void Update()
		{
			_managersUpdate.ForEach(m => m.Update());
		}

		public static void SetView(MainView view)
		{
			View = view;
		}
	}
}
