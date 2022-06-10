﻿using System.Collections.Generic;
using UnityEngine;

namespace WordMaster
{
	public class Context : MonoBehaviour
	{
		public static DictionaryManager DictionaryManager { get; private set; }
		public static Options Options { get; private set; }

		private static readonly List<BaseManager> _managers = new List<BaseManager>();

		private void Init()
		{
			Application.targetFrameRate = 45;
			Options = new Options();
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
	}
}
