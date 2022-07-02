using System;
using System.Text;
using UnityEngine;

namespace WordMaster
{
    public class Word : BaseModel
	{
		public enum DataType
		{
			Value,
			Translation,
			Transcription,
			Example,
			ExampleTranslation,
			Type
		}

        public const int MIN_RATIO = -5;
        public const int MAX_RATIO = 5;

		public static bool IsReversedWord;
        public static bool ShowWordLength;
        public static bool ShowFirstLetter;
        public static bool ShowCorrectWord;

        private string _value;
		private string _translation;
        private string _example;
        private string _exampleTranslation;
		private int _ratio;

		public string Value => IsReversedWord ? _translation : _value;
		public string Translation => IsReversedWord ? _value : _translation;
		public string Transcription { get; private set; }
		public string Type { get; private set; }
		public string Example => IsReversedWord ? _exampleTranslation : _example;
		public string ExampleTranslation => IsReversedWord ? _example : _exampleTranslation;

		public string ExampleForView
		{
			get
            {
                var text = Example;
				if (string.IsNullOrEmpty(text))
					return String.Empty;
                
                return ShowWordLength
                    ? text.Replace(Value, new string('*', Value.Length))
                    : text.Replace(Value, new string('*', 1));
            }
		}

		public string ValueForDto => _value;
		public string TranslationForDto => _translation;
        public string ExampleForDto => _example;
        public string ExampleTranslationForDto => _exampleTranslation;

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

        public int Viewed { get; private set; }

		public void SetData(DataType type, string str)
		{
			str = str.Trim();

			switch (type)
			{
				case DataType.Value: _value = str; break;
				case DataType.Translation: _translation = str; break;
				case DataType.Transcription: Transcription = str; break;
				case DataType.Example: _example = str; break;
				case DataType.ExampleTranslation: _exampleTranslation = str; break;
				case DataType.Type: Type = str; break;
			}
		}

		public Word()
		{

		}

		public Word(WordDto dto)
		{
			_value = dto.w;
			_translation = dto.tsl;
            _example = dto.ex;
            _exampleTranslation = dto.extr;

            Type = dto.t;
			Transcription = dto.tcr;

            _ratio = dto.r;
			Viewed = dto.v;
		}

		public void Update(Word other)
		{
			_value = other.Value;
			_translation = other.Translation;
            _example = other._example;
            _exampleTranslation = other._exampleTranslation;

            Type = other.Type;
            Transcription = other.Transcription;

            _ratio = other._ratio;
            Viewed = other.Viewed;
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

			bool isEqualLength = longText.Length == textForCheck.Length;
			return IsCorrectTranslation(textForCheck, isReverce) && isEqualLength;
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

		public string GetMaskedText(string textForCheck,
            bool isReverse,
			bool showFirstLetter,
            bool isAsterisk = true)
		{
			var fullText = isReverse ? _translation : _value;

			var result = string.Empty;

			if (ShowWordLength == false)
			{
				return result;
			}

            for (var i = 0; i < fullText.Length; i++)
			{
                if (i == 0 && string.IsNullOrEmpty(textForCheck) && ShowFirstLetter)
                {
                    result += fullText[i];
					continue;
                }

				if (i < textForCheck.Length)
				{
					result += " ";
					continue;
				}

				if (isAsterisk)
					result += fullText[i] != ' ' ? "*" : " ";
				else
					result += fullText[i];
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