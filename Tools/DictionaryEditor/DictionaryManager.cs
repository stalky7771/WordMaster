using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WordMaster;

namespace WordMasterEditor
{
	internal class DictionaryManager
	{
		public Dictionary Dictionary { get; private set; }
		public event Action<Dictionary> OnShowDictionary;

		public void LoadDictionary(string fileName)
		{
			try
			{
				using (var sr = new StreamReader(fileName))
				{
					string json = sr.ReadToEnd();
					var dict = JsonConvert.DeserializeObject<DictionaryDTO>(json);
					Dictionary = new Dictionary(dict);
				}
			}
			catch (IOException exc)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(exc.Message);
			}

			if (Dictionary != null)
				OnShowDictionary?.Invoke(Dictionary);
		}
	}
}
