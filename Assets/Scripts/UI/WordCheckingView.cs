using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WordMaster;

public class WordCheckingView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textTranslation;
	[SerializeField] private TextMeshProUGUI _textMasked;
	[SerializeField] private TMP_InputField _inputField;

	[SerializeField] private GameObject _checkPanel;
	[SerializeField] private GameObject _dictFinishedPanel;

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
		Context.DictionaryManager.OnPrintDictionary += OnPrintDictionary;
		Context.DictionaryManager.OnDictionaryFinished += OnDictionaryFinished;
	}

	private void Update()
	{
		FocusInputField();
	}

	private void FocusInputField()
	{
		CheckKeyDown();

		if (_inputField.isFocused)
			return;

		EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
		_inputField.ActivateInputField();
		_inputField.Select();

		//StartCoroutine(MoveTextEnd_NextFrame());
	}

	private void CheckKeyDown()
	{
		bool isCtrl = Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl);

		if (isCtrl && Input.GetKeyDown(KeyCode.Space))
		{
			print("Ctrl+S key was pressed");
		}

		if (Input.GetKeyDown(KeyCode.Delete))
		{
			Debug.Log(">>> delete key was pressed");
			Context.DictionaryManager.RemoveCurrentWord();
		}
	}

	public void OnValueChanged()
	{
		Context.DictionaryManager.ProcessWord(_inputField.text);
	}

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

	private void OnPrintDictionary(Dictionary dictionary)
	{
		//_textConsole.text = vocabulary.ToString();
	}

	private void OnDictionaryFinished()
	{
		_checkPanel.SetActive(false);
		_dictFinishedPanel.SetActive(true);
	}
}
