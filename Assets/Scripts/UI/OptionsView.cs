using UnityEngine;
using UnityEngine.UI;
using WordMaster;

public class OptionsView : MonoBehaviour
{
	[SerializeField] private Toggle _toggleShowWordLength;
	[SerializeField] private Toggle _toggleShowFirstLetter;
	[SerializeField] private Toggle _toggleShowTranslateAfterWrongTry;
	[SerializeField] private Toggle _toggleIsReversed;

	private void Awake()
	{
		_toggleShowWordLength.isOn = Context.Options.ShowWordLength;
		_toggleShowFirstLetter.isOn = Context.Options.ShowFirstLetter;
		_toggleShowTranslateAfterWrongTry.isOn = Context.Options.ShowCorrectWord;
		_toggleIsReversed.isOn = Context.Options.IsReversed;
	}

	public void OnToggleShowWordLength(bool val)
	{
		Context.Options.ShowWordLength = val;
	}

	public void OnToggleShowFirstLetter(bool val)
	{
		Context.Options.ShowFirstLetter = val;
	}

	public void OnToggleTranslateAfterWrongTry(bool val)
	{
		Context.Options.ShowCorrectWord = val;
	}

	public void OnToggleIsReversed(bool val)
	{
		Context.Options.IsReversed = val;
	}
}
