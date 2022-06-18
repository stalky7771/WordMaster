using System.Collections.Generic;
using UnityEngine;

namespace WordMaster
{
	public class Context : MonoBehaviour
	{
		public static DictionaryManager DictionaryManager { get; private set; }
		public static Options Options { get; private set; }
		public static FpsCounter FpsCounter { get; private set; }
		public static Version Version { get; private set; }
		public static MainView View { get; private set; }

		private static readonly List<BaseManager> _managers = new List<BaseManager>();

		private void Init()
		{
			Application.targetFrameRate = 45;
			Options = new Options();
			FpsCounter = new FpsCounter();
			Version = new Version();
			_managers.Add(DictionaryManager = new DictionaryManager());
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
			FpsCounter.Update();
			DictionaryManager.UpdateByTime();
		}

		public static void SetView(MainView view)
		{
			View = view;
		}
	}
}
