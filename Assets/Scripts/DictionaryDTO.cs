using System;
using System.Collections.Generic;

namespace WordMaster
{
	[Serializable]
	public class DictionaryDTO
	{
		public int version;
		public string name;
		public List<WordItemDTO> words;

		public DictionaryDTO()
		{

		}

		public DictionaryDTO(Dictionary dictionary)
		{
			version = dictionary.Version;
			name    = dictionary.Name;

			words = new List<WordItemDTO>();
			dictionary.Words.ForEach(w => words.Add(new WordItemDTO(w)));
		}
	}
}