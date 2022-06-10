using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WordMaster;

public class WordCheckingView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textTranslation;
	[SerializeField] private TextMeshProUGUI _textMasked;
	[SerializeField] private TMP_InputField _inputField;

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

	private void Start()
	{
		Context.DictionaryManager.OnUpdateUi += OnUpdateUI;
		Context.DictionaryManager.OnSetNewWord += OnSetNewWord;
		Context.DictionaryManager.OnPrintVocabulary += OnPrintVocabulary;
	}

	private void Update()
	{
		FocusInputField();
	}

	public void FocusInputField()
	{
		if (Input.GetKeyDown("delete"))
		{
			Debug.Log(">>> delete key was pressed");
			//Context.DictionaryManager.DeleteCurrentWord();
		}

		if (_inputField.isFocused)
			return;

		EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
		_inputField.ActivateInputField();
		_inputField.Select();

		//StartCoroutine(MoveTextEnd_NextFrame());
	}

	public void OnValueChanged()
	{
		//_inputManager.OnValueChanged();
		Context.DictionaryManager.ProcessWord(_inputField.text);
	}

	/*IEnumerator MoveTextEnd_NextFrame()
	{
		yield return 0;                 // Skip the first frame in which this is called.
		_inputField.MoveTextEnd(false); // Do this during the next frame.
	}*/

	private void OnUpdateUI()
	{
		Translation = Context.DictionaryManager.CurrentWord.Translation;
		Masked = Context.DictionaryManager.Masked;
	}

	private void OnSetNewWord(WordItem word)
	{
		_inputField.text = string.Empty;
		Translation = word.Translation;
		Masked = Context.DictionaryManager.Masked;
	}

	private void OnPrintVocabulary(Dictionary vocabulary)
	{
		//_textConsole.text = vocabulary.ToString();
	}
}
