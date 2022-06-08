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

		public DictionaryDTO(Dictionary vocabulary)
		{
			version = vocabulary.Version;
			name    = vocabulary.Name;

			words = new List<WordItemDTO>();
			vocabulary.Words.ForEach(w => words.Add(new WordItemDTO(w)));
		}
	}
}