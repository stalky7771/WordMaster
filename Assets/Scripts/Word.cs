using System.Text;
using UnityEngine;

namespace WordMaster
{
	public class Word
	{
		public const int MIN_RATIO = -5;
		public const int MAX_RATIO = 7;
		private string _value;
		private string _translation;
		private int _ratio;
		private int _viewed;

		public string Value => IsReversed ? _translation : _value;
		public string Translation => IsReversed ? _value : _translation;
		public string Transcription { get; private set; }
		public string Description { get; private set; }

		public string DescriptionWithCensure
		{
			get
			{
				if (Description != null)
				{
					return Description.Replace(Value, new string('*', Value.Length));
				}
				return string.Empty;
			}
		}

		public string ValueForDto => _value;
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

		public Word(string value, string translation, string transcription = "")
		{
			_value = value;
			_translation = translation;
			Transcription = transcription;
		}

		public Word(WordDto dto)
		{
			_value = dto.w;
			_translation = dto.tsl;
			Transcription = dto.tcr;
			Description = dto.dcr;

			_ratio = dto.r;
			_viewed = dto.v;
		}

		public void Update(Word other)
		{
			_value = other.Value;
			_translation = other.Translation;
			Transcription = other.Transcription;
			Description = other.Description;
		}

		private string GetString(string[] data, int index)
		{
			return index < data.Length ? data[index] : string.Empty;
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
			sb.Append(_value);
			sb.Append(" | ");
			sb.Append(_translation);
			sb.Append(" | ");
			sb.Append("[" + Transcription + "]");
			sb.Append(" | R:");
			sb.Append(Ratio);
			sb.Append(" | V:");
			sb.Append(Viewed);
			return sb.ToString();
		}

		public bool IsTranslateFinished(string textForCheck, bool isReverce)
		{
			string longText = !isReverce ? _value : _translation;

			bool isEqualLedgth = longText.Length == textForCheck.Length;
			return IsCorrectTranslation(textForCheck, isReverce) && isEqualLedgth;
		}

		public bool IsCorrectTranslation(string textForCheck, bool isReverce)
		{
			string translation = isReverce ? _translation : _value;

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
			string longText = isReverse ? _translation : _value;

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
			string translation = isReverse ? _translation : _value;

			if (textForCheck.Length != translation.Length)
			{
				return false;
			}

			return IsCorrectTranslation(textForCheck, isReverse);
		}
	}
}