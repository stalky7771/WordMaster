using System;
using System.Collections.Generic;

namespace WordMaster
{
	[Serializable]
	public class DictionaryDto
	{
		public List<WordDto> words;
		public DictionaryStatisticsDto statisticsDto;

		public DictionaryDto()
		{

		}

		public DictionaryDto(Dictionary dictionary)
		{
			words = new List<WordDto>();
			dictionary.Words.ForEach(w => words.Add(new WordDto(w)));


			statisticsDto = dictionary.Statistics != null
				? dictionary.Statistics.GetDto()
				: new DictionaryStatisticsDto();
		}
	}
}