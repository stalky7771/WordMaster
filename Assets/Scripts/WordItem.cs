using System.Text;
using UnityEngine;

public class WordItem
{
	private string _word;
	private string _translation;
	private string _transkription;
	private int _ratio;
	private int _viewed;

	public string Transcription => _transkription;

	public int Ratio
	{
		get => _ratio;
		set => _ratio = Mathf.Clamp(value, -5, 5);
	}

	public int Viewed
	{
		get => _viewed;
		private set => _viewed = value;
	}

	public static WordItem EmptyWord;

	static WordItem()
	{
		EmptyWord = new WordItem("empty word", "empty translation", "empty transkription");
	}

	public WordItem(string word, string translation, string transkription)
	{
		_word = word;
		_translation = translation;
		_transkription = transkription;
	}

	public WordItem(string[] data)
	{
		_word = GetString(data, 0);
		_translation = GetString(data, 1);
		_transkription = GetString(data, 2);
	}

	public WordItem(WordItemDTO dto)
	{
		_word = dto.word;
		_translation = dto.translation;
		_transkription = dto.transkription;
		_ratio = dto.ratio;
		_viewed = dto.viewed;
	}

	public string GetWord(bool isReversed = false)
	{
		return isReversed ? _translation : _word;
	}

	public string GetTranslation(bool isReversed = false)
	{
		return isReversed ? _word : _translation;
	}

	private string GetString(string[] data, int index)
	{
		return index < data.Length ? data[index] : string.Empty;
	}

	private int GetInt(string[] data, int index)
	{
		string str = GetString(data, index);
		if (string.IsNullOrEmpty(str))
			return 0;
		
		int.TryParse(str, out int result);
		return result;
	}

	public void AnswerCorrect()
	{
		Ratio++;
		Viewed++;
	}

	public void AnswerWrong()
	{
		Ratio--;
	}

	public void Clear()
	{
		Ratio = 0;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(_word);
		sb.Append(" | ");
		sb.Append(_translation);
		sb.Append(" | ");
		sb.Append("[" + _transkription + "]");
		sb.Append(" | R:");
		sb.Append(Ratio);
		sb.Append(" | V:");
		sb.Append(Viewed);
		return sb.ToString();
	}

	public bool IsTranslateFinished(string textForCheck, bool isReverce)
	{
		string longText = !isReverce ? _word : _translation;

		bool isEqualLedgth = longText.Length == textForCheck.Length;
		return IsCorrectTranslation(textForCheck, isReverce) && isEqualLedgth;
	}

	public bool IsCorrectTranslation(string textForCheck, bool isReverce)
	{
		string translation = isReverce ? _translation : _word;

		for (int i = 0; i < Mathf.Min(textForCheck.Length, translation.Length); i++)
		{
			if (textForCheck.Length < i || translation.Length < i)
				return false;

			if (textForCheck[i] != translation[i])
				return false;
		}
		return true;
	}

	public string GetMaskedText(string textForCheck, bool isReverse)
	{
		string longText = isReverse ? _translation : _word;

		string result = string.Empty;

		if (Options.ShowWordLength == false)
		{
			return result;
		}

		if (Options.ShowFirstLetter && string.IsNullOrEmpty(textForCheck))
		{
			textForCheck = _translation.Substring(0, 1);
		}

		for (int i = 0; i < longText.Length; i++)
		{
			if (i < textForCheck.Length)
			{
				result += longText[i];
				continue;
			}

			result += longText[i] != ' ' ? "*" : " ";
		}

		return result;
	}

	public bool IsFullTranslation(string textForCheck, bool isReverse)
	{
		string translation = isReverse ? _translation : _word;

		if (textForCheck.Length != translation.Length)
		{
			return false;
		}

		return IsCorrectTranslation(textForCheck, isReverse);
	}
}
