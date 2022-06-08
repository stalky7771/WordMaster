using System;
using UnityEngine;

namespace WordMaster
{
	public class Options
	{
		private const string SHOW_WORD_LENGTH = "ShowWordLength";
		private const string SHOW_FIRST_LETTER = "ShowFirstLetter";
		private const string SHOW_CORRECT_WORD = "ShowCorrectWord";
		private const string IS_REVERSED = "IsReversed";

		public event Action OnUpdate;

		public Options()
		{
			WordItem.IsReversed = IsReversed;
			WordItem.ShowWordLength = ShowWordLength;
			WordItem.ShowFirstLetter = ShowFirstLetter;
		}

		public bool ShowWordLength
		{
			get => GetBool(SHOW_WORD_LENGTH);
			set
			{
				WordItem.ShowWordLength = value;
				SetBool(SHOW_WORD_LENGTH, value);
				OnUpdate?.Invoke();
			}

		}

		public bool ShowFirstLetter
		{
			get => GetBool(SHOW_FIRST_LETTER);
			set
			{
				WordItem.ShowFirstLetter = value;
				SetBool(SHOW_FIRST_LETTER, value);
				OnUpdate?.Invoke();
			}
		}

		public bool ShowCorrectWord
		{
			get => GetBool(SHOW_CORRECT_WORD);
			set
			{
				SetBool(SHOW_CORRECT_WORD, value);
				OnUpdate?.Invoke();
			}
		}

		public bool IsReversed
		{
			get => GetBool(IS_REVERSED);
			set
			{
				WordItem.IsReversed = value;
				SetBool(IS_REVERSED, value);
				OnUpdate?.Invoke();
			}
		}

		private static bool GetBool(string key)
		{
			return PlayerPrefs.GetInt(key, 0) != 0;
		}

		private static void SetBool(string key, bool val)
		{
			PlayerPrefs.SetInt(key, val ? 1 : 0);
		}
	}
}