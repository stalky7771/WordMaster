using System;

namespace WordMaster
{
	[Serializable]
	public class WordItemDTO
	{
		public string w;
		public string tsl;
		public string tcr;
		public int r;
		public int v;

		public WordItemDTO()
		{

		}

		public WordItemDTO(WordItem wordItem)
		{
			w = wordItem.WordForDto;
			tsl = wordItem.TranslationForDto;
			tcr = wordItem.Transcription;
			r = wordItem.Ratio;
			v = wordItem.Viewed;
		}
	}
}