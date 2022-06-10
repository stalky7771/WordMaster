using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace WordMaster
{
	[Serializable]
	public class Dictionary
	{
		[SerializeField] private int _version;
		[SerializeField] private string _name;
		[SerializeField] private List<WordItem> _words = new List<WordItem>();
		[SerializeField] private string _path;
		[SerializeField] private int _currentIndex;

		public int Version => _version;
		public string Name => _name;
		public List<WordItem> Words => _words;
		public string Path => _path;

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

		public WordItem NextWord
		{
			get
			{
				if (IsEmpty)
				{
					return WordItem.EmptyWord;
				}

				_currentIndex++;

				if (_currentIndex > _words.Count - 1)
					_currentIndex = 0;

				return _words[_currentIndex];
			}
		}

		public bool IsEmpty => _words.Count == 0;

		public void SaveToJson(string path)
		{
			using var outputFile = new StreamWriter(path);
			outputFile.Write(JsonHelper.Serialize(new DictionaryDTO(this)));
		}

		public void LoadFromJson(string path)
		{
			if (File.Exists(path) == false)
				return;

			string json = File.ReadAllText(path);
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
			StringBuilder sb = new StringBuilder();

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