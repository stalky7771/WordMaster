using System.Collections.Generic;
using UnityEngine;

namespace WordMaster
{
	public class Context : MonoBehaviour
	{
		public static DictionaryManager DictionaryManager { get; private set; }
		public static Options Options { get; private set; }
		public static FpsManager FpsManager { get; private set; }
		public static Version Version { get; private set; }
		public static MainView View { get; private set; }

		private readonly List<BaseManager> _managers = new List<BaseManager>();

		private void Init()
		{
			Application.targetFrameRate = 45;
			Options = new Options();
			Version = new Version();
			_managers.Add(DictionaryManager = new DictionaryManager());
			_managers.Add(FpsManager = new FpsManager());
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
			_managers.ForEach(m => m.Update());
		}

		public static void SetView(MainView view)
		{
			View = view;
		}
	}
}
