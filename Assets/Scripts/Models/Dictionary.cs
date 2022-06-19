using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace WordMaster
{
	public class Dictionary
	{
		private List<Word> _words = new();

		public int Version { get; private set; }
		public float Time { get; private set; }
		public string Name { get; private set; }
		public string FileName { get; private set; }
		

		public List<Word> Words => _words;

		public bool IsFinished => _words.Where(w => w.Ratio != Word.MAX_RATIO).ToList().Count == 0;

		public bool IsEmpty => _words.Count == 0;

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

				var availableWords = _words.Where(w => w.Ratio < Word.MAX_RATIO).OrderBy(w => w.Viewed).ToList();

				var wordWithMinVied = availableWords[0];

				var allWordsWithSameView = availableWords.Where(w => w.Viewed == wordWithMinVied.Viewed).ToList();

				return allWordsWithSameView[Random.Range(0, allWordsWithSameView.Count - 1)];
			}
		}

		public float Progress
		{
			get
			{
				float sum = 0;
				_words.ForEach(w => sum += w.CompleteRatio);
				return sum / _words.Count;
			}
		}

		private Word FindWordWithWorstRatio(float probability)
		{
			if (Random.value > probability)
				return null;

			int minRatio = _words.Min(w => w.Ratio);
			return _words.Find(w => w.Ratio == minRatio);
		}

		public void SaveToJson(string path)
		{
			FileName = path;
			using var outputFile = new StreamWriter(path);
			outputFile.Write(JsonHelper.Serialize(new DictionaryDto(this)));
		}

		public void LoadFromJson(string fileName)
		{
			if (File.Exists(fileName) == false)
				return;

			FileName = fileName;

			string json = File.ReadAllText(fileName);
			var dto = JsonHelper.Deserialize(json);

			Version = dto.version;
			Name = dto.name;
			Time = dto.time;
			_words = new List<Word>();

			dto.words.ForEach(wordItemDto =>
			{
				_words.Add(new Word(wordItemDto));
			});
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			foreach (var w in _words)
			{
				var transcription = "[" + w.Transcription + "]";
				sb.Append($"{w.Value,-12} {w.Translation,-12} {w.Ratio,-3} {transcription,-12}\n");
			}

			return sb.ToString();
		}

		public Word GetWordItem(int index)
		{
			return index >= _words.Count ? null : _words[index];
		}

		public void RemoveWord(Word word)
		{
			_words.Remove(word);
		}

		public void RemoveWord(int index)
		{
			_words.RemoveAt(index);
		}

		public void AddWord(Word word)
		{
			_words.Add(word);
		}

		public void AddDeltaTime(float deltaTime)
		{
			Time += deltaTime;
		}

		public string TimeToString => (new TimeSpan(0, 0, 0, (int)Time)).ToString(@"hh\:mm\:ss");
	}
}