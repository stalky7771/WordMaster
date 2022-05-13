using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TranslatePageView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textTranslation;
	[SerializeField] private TextMeshProUGUI _textMasked;
	[SerializeField] private TextMeshProUGUI _textStatusBar;
	[SerializeField] private TextMeshProUGUI _textConsole;

	[SerializeField] private TMP_InputField _inputField;

	private InputManager _inputManager => Context.InputManager;

	public string InputField
	{
		get => _inputField.text;
		set => _inputField.text = value;
	}

	public string Translation
	{
		get => _textTranslation.text;
		set => _textTranslation.text = value.ToMonoSpace();
	}

	public string Masked
	{
		get => _textMasked.text;
		set => _textMasked.text = value.ToMonoSpace();
	}

	public string StatusBar
	{
		set => _textStatusBar.text = value.ToMonoSpace();
	}

	public string Console
	{
		set => _textConsole.text = value;
	}

	private void Start()
	{
		Context.InputManager.SetView(this);
		Context.InputManager.UpdateWord();

		StatusBar = string.Empty;
	}

	public void FocusInputField()
	{
		if(_inputField.isFocused)
			return;

		EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
		_inputField.ActivateInputField();
		_inputField.Select();

		//StartCoroutine(MoveTextEnd_NextFrame());
	}

	public void OnValueChanged()
	{
		_inputManager.OnValueChanged();
	}

	public void OnEndEdit()
	{
		_inputManager.OnEndEdit();
	}

	IEnumerator MoveTextEnd_NextFrame()
	{
		yield return 0;                 // Skip the first frame in which this is called.
		_inputField.MoveTextEnd(false); // Do this during the next frame.
	}
}
