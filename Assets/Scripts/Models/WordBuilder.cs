namespace WordMaster
{
    public class WordBuilder
    {
        private Word _word;

        public WordBuilder Add(Word.DataType type, string text)
        {
            _word ??= new Word();

            _word.SetData(type, text);
            return this;
        }

        public Word ToWord
        {
            get
            {
                _word ??= new Word();
                return _word;
            }
        }
    }
}