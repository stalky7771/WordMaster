using System;
using System.IO;
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

		public void ConvertDictionary()
		{
			/*string fileIn = @"D:\_RESEARCH\UNITY\L15b.txt";
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

					Word wordItem = new Word(wordPair[0], wordPair[1]);
					newDictionary.AddWord(wordItem);
				}

				newDictionary.SaveToJson(fileOut);


				int aaa = 0;
			}*/
		}
	}
}
