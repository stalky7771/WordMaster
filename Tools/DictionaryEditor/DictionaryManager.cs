﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordMaster;

namespace WordMasterEditor
{
	internal class DictionaryManager
	{
		public int FocusedIndex { get; private set; }
		public Dictionary Dictionary { get; private set; }
		public event Action<Dictionary> OnShowDictionary;
		public event Action<string> OnUpdateStatusBar;

		public string FilePath { get; private set; }

		public void Load(string filePath)
		{
			Dictionary = new Dictionary();
			Dictionary.LoadFromJson(filePath);
			OnUpdateStatusBar?.Invoke(FilePath);
			UpdateView();
		}

		public void AddWord(Word word)
		{
			Dictionary.AddWord(word);
			UpdateView();
		}

		public void UpdateWord(Word newWord)
		{
			if (FocusedIndex == -1)
				return;

			Word word = Dictionary.GetWordItem(FocusedIndex);
			word?.Update(newWord);

			UpdateView();
		}

		public void RemoveWord(int index)
		{
			Dictionary.RemoveWord(index);
		}

		public void SetFocusedIndex(int index)
		{
			FocusedIndex = index;
		}

		private void UpdateView()
		{
			if (Dictionary != null)
				OnShowDictionary?.Invoke(Dictionary);
		}

		public void ConvertCSVtoDictionary(string fileName)
		{
			
			var fileIn = fileName;
			var fileOut = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileIn) + ".dict";

			using (var sr = new StreamReader(fileIn))
			{
				var newDictionary = new Dictionary();

				var text = sr.ReadToEnd();
				var lines = text.Split('\n');
				var words = lines.ToList();
				foreach (var t in words)
				{
					var w = t;
					w = w.Replace("\r", "");
					w = w.Trim();

					if (string.IsNullOrEmpty(w))
						break;

					var wordPair = w.Split(';');

					var wordItem = new Word(wordPair[0], wordPair[1]);
					newDictionary.AddWord(wordItem);
				}

				newDictionary.SaveToJson(fileOut);
			}
		}
	}
}
