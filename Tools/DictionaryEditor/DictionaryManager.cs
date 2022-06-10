using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WordMaster;

namespace WordMasterEditor
{
	internal class DictionaryManager
	{
		public int FocusedIndex { get; private set; }
		public Dictionary Dictionary { get; private set; }
		public event Action<Dictionary> OnShowDictionary;

		public void Load(string fileName)
		{
			try
			{
				using (var sr = new StreamReader(fileName))
				{
					string json = sr.ReadToEnd();
					Dictionary = new Dictionary(JsonHelper.Deserialize(json));
				}
			}
			catch (IOException exc)
			{
				//Console.WriteLine("The file could not be read:");
				//Console.WriteLine(exc.Message);
			}

			UpdateView();
		}

		public void AddWord(WordItem word)
		{
			Dictionary.AddWord(word);
			UpdateView();
		}

		public void UpdateWord(WordItem newWord)
		{
			if (FocusedIndex == -1)
				return;

			WordItem word = Dictionary.GetWordItem(FocusedIndex);
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

		public void ConvertDictionary()
		{
			string fileIn = @"D:\_RESEARCH\UNITY\L15b.txt";
			string fileOut = @"D:\_RESEARCH\UNITY\L15.dict";

			using (var sr = new StreamReader(fileIn))
			{
				Dictionary newDictionary = new Dictionary();

				string text = sr.ReadToEnd();
				string[] lines = text.Split('\n');
				List<string> words = lines.ToList();
				for (int i = 0; i < words.Count; i++)
				{
					string w = words[i];
					w.Replace("\r", "");
					w = w.Trim();
					string[] wordPair = w.Split(';');

					WordItem wordItem = new WordItem(wordPair[0], wordPair[1]);
					newDictionary.AddWord(wordItem);
				}

				newDictionary.SaveToJson(fileOut);


				int aaa = 0;
			}
		}
	}
}
