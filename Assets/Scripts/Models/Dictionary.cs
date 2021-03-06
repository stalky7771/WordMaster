using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace WordMaster
{
	public class Dictionary : BaseModel
	{
		public string FileName { get; private set; }

		public List<Word> Words { get; private set; } = new();

		public DictionaryStatistics Statistics { get; private set; }

		public bool IsFinished => Words.Where(w => w.Ratio != Word.MAX_RATIO).ToList().Count == 0;

		public bool IsEmpty => Words.Count == 0;

		public Word NextWord
		{
			get
			{
				if (IsEmpty || IsFinished)
				{
					return null;
				}

				var worstWord = FindWordWithWorstRatio(0.3f);
				if (worstWord != null)
					return worstWord;

				var availableWords = Words.Where(w => w.Ratio < Word.MAX_RATIO).OrderBy(w => w.Viewed).ToList();

				var wordWithMinVied = availableWords[0];

				var allWordsWithSameView = availableWords.Where(w => w.Viewed == wordWithMinVied.Viewed).ToList();

				return allWordsWithSameView[Random.Range(0, allWordsWithSameView.Count - 1)];
			}
		}

		public string Progress
		{
			get
			{
				float sum = 0;
				Words.ForEach(w => sum += w.CompleteRatio);
				return "Progress: " + (sum / Words.Count).ToString("P1");
			}
		}

		public string FinishedWords
		{
			get
			{
				var finishedWords = Words.Where(w => w.Ratio == Word.MAX_RATIO).ToList().Count;
				var allWords = Words.Count;
				return $"Finished: {finishedWords}/{allWords}";
			}
		}

        public void Save(string fileName)
        {
            var json = PersistenceHelper.SaveToJson(new DictionaryDto(this));
            PersistenceHelper.WriteToFile(fileName, json);
        }

        public void Load(string fileName)
        {
            var json = PersistenceHelper.ReadFromFile(fileName);
            var dto = PersistenceHelper.LoadFromJson<DictionaryDto>(json);

            FileName = fileName;

            Words = new List<Word>();

            dto?.words.ForEach(wordItemDto =>
            {
                Words.Add(new Word(wordItemDto));
            });

            Statistics = new DictionaryStatistics(dto?.statisticsDto, this);
        }

        public void ResetProgress()
        {
			Words.ForEach(w => w.Ratio = 0);
			Statistics.ResetTime();
        }

		private Word FindWordWithWorstRatio(float probability)
		{
			if (Random.value > probability)
				return null;

			var minRatio = Words.Min(w => w.Ratio);
			return Words.Find(w => w.Ratio == minRatio);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

            var index = 0;
			foreach (var w in Words)
			{
				//var transcription = "[" + w.Transcription + "]";
				sb.AppendLine($"{index++,-4} {w.Value,-32} {w.Translation,-42} {w.Ratio,2}"); // {transcription,-20}\n");
			}

			return sb.ToString();
		}

		public Word GetWordItem(int index)
		{
			return index >= Words.Count ? null : Words[index];
		}

		public void RemoveWord(Word word)
		{
			Words.Remove(word);
		}

		public void RemoveWord(int index)
		{
			Words.RemoveAt(index);
		}

		public void AddWord(Word word)
		{
			Words.Add(word);
		}

		public void AddDeltaTime(float deltaTime)
		{
			Statistics.AddDeltaTime(deltaTime);
		}

		public string TimeToString => (new TimeSpan(0, 0, 0, (int)Statistics.Time)).ToString(@"hh\:mm\:ss");
	}
}