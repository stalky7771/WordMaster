using System;

namespace WordMaster
{
	[Serializable]
	public class WordDto
    {
        public string t;
		public string w;
		public string tsl;
		public string tcr;
		public string ex;
        public string extr;
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
			ex = word.ExampleForDto;
            extr = word.ExampleTranslationForDto;
            t = word.Type;
			r = word.Ratio;
			v = word.Viewed;
		}
	}
}