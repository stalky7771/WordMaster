using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WordMaster
{
	[Serializable]
	public class Dictionary
	{
		[SerializeField] private int _version;
		[SerializeField] private string _name;
		[SerializeField] private List<WordItem> _words = new List<WordItem>();
		[SerializeField] private string _fileName;

		public int Version => _version;
		public string Name => _name;
		public List<WordItem> Words => _words;
		public string FileName => _fileName;

		public Dictionary()
		{

		}

		public Dictionary(DictionaryDTO dto)
		{
			_version = dto.version;
			_name = dto.name;
			_words = new List<WordItem>();

			dto.words.ForEach(wordItemDto =>
			{
				_words.Add(new WordItem(wordItemDto));
			});
		}

		public void SetDefaultData()
		{
			_words.Clear();

			_words.Add(new WordItem("cat", "кот", "kæt"));
			_words.Add(new WordItem("dog", "собака", "dɒg"));
			_words.Add(new WordItem("chess", "шахматы", "ʧɛs"));
			_words.Add(new WordItem("whether", "погода", "ˈwɛðə"));
		}

		public bool IsFinished => _words.Where(w => w.Ratio != WordItem.MAX_RATIO).ToList().Count == 0;

		public bool IsEmpty => _words.Count == 0;

		public WordItem NextWord
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

				var availableWords = _words.Where(w => w.Ratio < WordItem.MAX_RATIO).OrderBy(w => w.Viewed).ToList();

				var wordWithMinVied = availableWords[0];

				var allWordsWithSameView = availableWords.Where(w => w.Viewed == wordWithMinVied.Viewed).ToList();

				return allWordsWithSameView[Random.Range(0, allWordsWithSameView.Count - 1)];
			}
		}

		private WordItem FindWordWithWorstRatio(float probability)
		{
			if (Random.value > probability)
				return null;

			int minRatio = _words.Min(w => w.Ratio);
			return _words.Find(w => w.Ratio == minRatio);
		}

		public void SaveToJson(string path)
		{
			_fileName = path;
			using var outputFile = new StreamWriter(path);
			outputFile.Write(JsonHelper.Serialize(new DictionaryDTO(this)));
		}

		public void LoadFromJson(string fileName)
		{
			if (File.Exists(fileName) == false)
				return;

			_fileName = fileName;

			string json = File.ReadAllText(fileName);
			var dto = JsonHelper.Deserialize(json);

			_version = dto.version;
			_name = dto.name;
			_words = new List<WordItem>();

			dto.words.ForEach(wordItemDto =>
			{
				_words.Add(new WordItem(wordItemDto));
			});
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			foreach (var w in _words)
			{
				string transcription = "[" + w.Transcription + "]";
				sb.Append($"{w.Word,-12} {w.Translation,-12} {w.Ratio,-3} {transcription,-12}\n");
			}

			return sb.ToString().ToMonoSpace();
		}

		public void DeleteWord(WordItem word)
		{
			_words.Remove(word);
		}

		public WordItem GetWordItem(int index)
		{
			if (index >= _words.Count)
				return null;

			return _words[index];
		}

		public void AddWord(WordItem word)
		{
			_words.Add(word);
		}
		
		public void RemoveWord(int index)
		{
			_words.RemoveAt(index);
		}
	}
}