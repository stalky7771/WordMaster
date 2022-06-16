using System.Text;
using UnityEngine;

namespace WordMaster
{
	public class WordItem
	{
		public const int MIN_RATIO = -5;
		public const int MAX_RATIO = 7;
		private string _word;
		private string _translation;
		private string _transcription;
		private int _ratio;
		private int _viewed;

		public string Word => IsReversed ? _translation : _word;
		public string Translation => IsReversed ? _word : _translation;
		public string Transcription => _transcription;

		public string WordForDto => _word;
		public string TranslationForDto => _translation;

		public int Ratio
		{
			get => _ratio;
			set => _ratio = Mathf.Clamp(value, MIN_RATIO, MAX_RATIO);
		}

		public static bool IsReversed { get; set; }
		public static bool ShowWordLength { get; set; }
		public static bool ShowFirstLetter { get; set; }

		public int Viewed
		{
			get => _viewed;
			private set => _viewed = value;
		}

		public WordItem(string word, string translation, string transcription = "")
		{
			_word = word;
			_translation = translation;
			_transcription = transcription;
		}

		public WordItem(string[] data)
		{
			_word = GetString(data, 0);
			_translation = GetString(data, 1);
			_transcription = GetString(data, 2);
		}

		public WordItem(WordItemDTO dto)
		{
			_word = dto.w;
			_translation = dto.tsl;
			_transcription = dto.tcr;
			_ratio = dto.r;
			_viewed = dto.v;
		}

		public void Update(WordItem other)
		{
			_word = other.Word;
			_translation = other.Translation;
			_transcription = other.Transcription;
		}

		private string GetString(string[] data, int index)
		{
			return index < data.Length ? data[index] : string.Empty;
		}

		/*private int GetInt(string[] data, int index)
		{
			string str = GetString(data, index);
			if (string.IsNullOrEmpty(str))
				return 0;

			int.TryParse(str, out int result);
			return result;
		}*/

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
			sb.Append("[" + _transcription + "]");
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

			if (ShowWordLength == false)
			{
				return result;
			}

			if (ShowFirstLetter && string.IsNullOrEmpty(textForCheck))
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
}