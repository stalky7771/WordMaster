using UnityEngine;
using UnityEngine.UI;
using WordMaster;

public class OptionsView : MonoBehaviour
{
	[SerializeField] private Toggle _toggleShowWordLength;
	[SerializeField] private Toggle _toggleShowFirstLetter;
	[SerializeField] private Toggle _toggleShowTranslateAfterWrongTry;
	[SerializeField] private Toggle _toggleIsReversed;

	[SerializeField] private Transform _buttonShow;
	[SerializeField] private GameObject _panelToggles;

	private void Start()
	{
		_toggleShowWordLength.isOn = Context.Config.ShowWordLength;
		_toggleShowFirstLetter.isOn = Context.Config.ShowFirstLetter;
		_toggleShowTranslateAfterWrongTry.isOn = Context.Config.ShowCorrectWord;
		_toggleIsReversed.isOn = Context.Config.IsReversedWord;

		_panelToggles.SetActive(Context.Config.ShowOptionsPanel);
        SetArrowDirection(Context.Config.ShowOptionsPanel);
	}

    public void OnToggleShowWordLength(bool val)
	{
		Context.Config.ShowWordLength = val;
	}

	public void OnToggleShowFirstLetter(bool val)
	{
		Context.Config.ShowFirstLetter = val;
	}

	public void OnToggleTranslateAfterWrongTry(bool val)
	{
		Context.Config.ShowCorrectWord = val;
	}

	public void OnToggleIsReversed(bool val)
	{
		Context.Config.IsReversedWord = val;
	}

	public void OnClickShowOptions()
	{
		_panelToggles.SetActive(!_panelToggles.activeSelf);
		Context.Config.ShowOptionsPanel = _panelToggles.activeSelf;
        SetArrowDirection(Context.Config.ShowOptionsPanel);
    }

    private void SetArrowDirection(bool isLeft)
    {
        _buttonShow.transform.localScale = new Vector3(isLeft ? -1 : 1, 1, 1);
	}
}
