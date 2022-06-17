using System;

namespace WordMaster
{
	[Serializable]
	public class WordDto
	{
		public string w;
		public string tsl;
		public string tcr;
		public string dcr;
		public int r;
		public int v;

		public WordDto()
		{

		}

		public WordDto(Word word)
		{
			w = word.ValueForDto;
			tsl = word.TranslationForDto;
			tcr = word.Transcription;
			dcr = word.Description;
			r = word.Ratio;
			v = word.Viewed;
		}
	}
}