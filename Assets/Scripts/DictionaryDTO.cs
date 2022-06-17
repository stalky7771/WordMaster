using System;
using System.Collections.Generic;

namespace WordMaster
{
	[Serializable]
	public class DictionaryDto
	{
		public int version;
		public string name;
		public List<WordDto> words;

		public DictionaryDto()
		{

		}

		public DictionaryDto(Dictionary dictionary)
		{
			version = dictionary.Version;
			name    = dictionary.Name;

			words = new List<WordDto>();
			dictionary.Words.ForEach(w => words.Add(new WordDto(w)));
		}
	}
}