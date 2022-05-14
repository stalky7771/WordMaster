using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
	private const string SHOW_WORD_LENGTH = "ShowWordLength";
	private const string SHOW_FIRST_LETTER = "ShowFirstLetter";
	private const string SHOW_TRANSLATE_AFTER_WRONG_TRY = "ShowTranslateAfterWrongTry";
	private const string IS_REVERSED = "IsReversed";

	[SerializeField] private Toggle _toggleShowWordLength;
	[SerializeField] private Toggle _toggleShowFirstLetter;
	[SerializeField] private Toggle _toggleShowTranslateAfterWrongTry;
	[SerializeField] private Toggle _toggleIsReversed;

	private void Awake()
	{
		_toggleShowWordLength.isOn = ShowWordLength;
		_toggleShowFirstLetter.isOn = ShowFirstLetter;
		_toggleShowTranslateAfterWrongTry.isOn = ShowTranslateAfterWrongTry;
		_toggleIsReversed.isOn = IsReversed;
	}

	public static bool ShowWordLength
	{
		get => GetBool(SHOW_WORD_LENGTH);
		set => SetBool(SHOW_WORD_LENGTH, value);
	}

	public static bool ShowFirstLetter
	{
		get => GetBool(SHOW_FIRST_LETTER);
		set => SetBool(SHOW_FIRST_LETTER, value);
	}

	public static bool ShowTranslateAfterWrongTry
	{
		get => GetBool(SHOW_TRANSLATE_AFTER_WRONG_TRY);
		set => SetBool(SHOW_TRANSLATE_AFTER_WRONG_TRY, value);
	}

	public static bool IsReversed
	{
		get => GetBool(IS_REVERSED);
		set => SetBool(IS_REVERSED, value);
	}

	private static bool GetBool(string key)
	{
		return PlayerPrefs.GetInt(key, 0) != 0;
	}

	private static void SetBool(string key, bool val)
	{
		PlayerPrefs.SetInt(key, val ? 1 : 0);
	}

	public void OnToggleShowWordLength(bool val)
	{
		ShowWordLength = val;
	}

	public void OnToggleShowFirstLetter(bool val)
	{
		ShowFirstLetter = val;
	}

	public void OnToggleTranslateAfterWrongTry(bool val)
	{
		ShowTranslateAfterWrongTry = val;
	}

	public void OnToggleIsReversed(bool val)
	{
		IsReversed = val;
	}
}
