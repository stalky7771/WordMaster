using System;
using WordMaster;

namespace WordMasterEditor
{
	internal class DictionaryManager
	{
		public int FocusedIndex { get; private set; }
		public Dictionary Dictionary { get; private set; }
		public event Action<Dictionary> OnShowDictionary;
		public event Action<string> OnUpdateStatusBar;

		public string FileName { get; private set; }

		public void Load(string fileName)
		{
            var json = PersistenceHelper.ReadFromFile(fileName);
            var dto = PersistenceHelper.LoadFromJson<DictionaryDto>(json);

            Dictionary = new Dictionary();
			Dictionary.Load(fileName);
			OnUpdateStatusBar?.Invoke(FileName);
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
			throw new NotImplementedException();

			/*var fileIn = fileName;
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

					var word = wordPair[0];
					var translate = wordPair[1];
					var example = string.Empty;

					if (wordPair.Length > 2)
						example = wordPair[2];

					var wordItem = new Word(word, translate, example);
					newDictionary.AddWord(wordItem);
				}

                var json = PersistenceHelper.SaveToJson(new DictionaryDto(newDictionary));
                PersistenceHelper.WriteToFile(fileOut, json);
		    }*/
		}
	}
}
