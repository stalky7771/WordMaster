using System.Text;
using UnityEngine;

namespace WordMaster
{
	public class Word
	{
		public enum DataType
		{
			Value,
			Translation,
			Transcription,
			Description
		}

		public const int MIN_RATIO = -5;
		public const int MAX_RATIO = 7;
		private string _value;
		private string _translation;
		private int _ratio;

		public string Value => IsReversed ? _translation : _value;
		public string Translation => IsReversed ? _value : _translation;
		public string Transcription { get; private set; }
		public string Example { get; private set; }

		public string DescriptionWithCensure
		{
			get
			{
				if (Example != null)
				{
					return Example.Replace(Value, new string('*', Value.Length));
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

		public float CompleteRatio
		{
			get
			{
				var tmp = Mathf.Clamp(_ratio, 0, MAX_RATIO);
				return tmp / (float)(MAX_RATIO);
			}
		}

		public static bool IsReversed { get; set; }
		public static bool ShowWordLength { get; set; }
		public static bool ShowFirstLetter { get; set; }
		public int Viewed { get; private set; }

		public void SetData(DataType type, string str)
		{
			str = str.Trim();

			switch (type)
			{
				case DataType.Value: _value = str; break;
				case DataType.Translation: _translation = str; break;
				case DataType.Transcription: Transcription = str; break;
				case DataType.Description: Example = str; break;
			}
		}

		public Word()
		{

		}

		public Word(WordDto dto)
		{
			_value = dto.w;
			_translation = dto.tsl;
			Transcription = dto.tcr;
			Example = dto.expl;

			_ratio = dto.r;
			Viewed = dto.v;
		}

		public void Update(Word other)
		{
			_value = other.Value;
			_translation = other.Translation;
			Transcription = other.Transcription;
			Example = other.Example;
		}

		/*private string GetString(string[] data, int index)
		{
			return index < data.Length ? data[index] : string.Empty;
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

			for (var i = 0; i < longText.Length; i++)
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