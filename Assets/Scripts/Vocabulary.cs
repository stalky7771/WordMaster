using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Vocabulary
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

	public Vocabulary()
	{

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

	public void LoadFromCSV(string path)
	{
		_words.Clear();

		string allText = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
		string[] stringSeparators = new string[] { "\r\n" };
		List<string> lines   = allText.Split(stringSeparators, StringSplitOptions.None).ToList();
		lines.RemoveAll(s => s.Length < 3);

		foreach (string line in lines)
		{
			if (line.Length < 5)
				continue;

			string[] wordRecord = line.Split(';');
			_words.Add(new WordItem(wordRecord));
		}
	}

	public void SaveToJson(string path)
	{
		string json = JsonUtility.ToJson(new VocabularyDTO(this), true);

		using (StreamWriter outputFile = new StreamWriter(path))
		{
			outputFile.Write(json);
		}
	}

	public void LoadFromJson(string path)
	{
		if (File.Exists(path) == false)
			return;
		
		string fileContents = File.ReadAllText(path);
		VocabularyDTO dto = JsonUtility.FromJson<VocabularyDTO>(fileContents);

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
			sb.Append($"{w.GetWord(),-12} {w.GetTranslation(),-12} {w.Ratio,-3} {transcription,-12}\n");
		}

		return sb.ToString().ToMonoSpace();
	}
}