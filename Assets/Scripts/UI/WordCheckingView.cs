using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WordMaster;

public class WordCheckingView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textTranslation;
	[SerializeField] private TextMeshProUGUI _textMasked;
	[SerializeField] private TextMeshProUGUI _textExample;
	[SerializeField] private TextMeshProUGUI _textType;
	[SerializeField] private TMP_InputField _inputField;

	[SerializeField] private GameObject _checkPanel;
	[SerializeField] private GameObject _dictFinishedPanel;

	[SerializeField] private WordProgressView _wordProgressView;

	private DictionaryManager DictManager => Context.DictionaryManager;

    private void Start()
	{
		DictManager.OnUpdateUi += OnUpdateUI;
		DictManager.OnSetNewWord += OnSetNewWord;
		DictManager.OnPrintDictionary += OnPrintDictionary;
		DictManager.OnDictionaryFinished += OnDictionaryFinished;
	}

	//private void OnEnable()
	//{
	//	DictManager.OnUpdateUi += OnUpdateUI;
	//	DictManager.OnSetNewWord += OnSetNewWord;
	//	DictManager.OnPrintDictionary += OnPrintDictionary;
	//	DictManager.OnDictionaryFinished += OnDictionaryFinished;
	//}

	//private void OnDisable()
	//{
	//	DictManager.OnUpdateUi -= OnUpdateUI;
	//	DictManager.OnSetNewWord -= OnSetNewWord;
	//	DictManager.OnPrintDictionary -= OnPrintDictionary;
	//	DictManager.OnDictionaryFinished -= OnDictionaryFinished;
	//}

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

		if (Input.GetKeyDown(KeyCode.Return))
		{
			//_inputField
			//var temp = _inputField.text;
			//_inputField.text = string.Empty;
			//_inputField.text = "777";
			//Context.DictionaryManager.InputWord(_inputField.text, true);

			//var eventSystem = EventSystem.current;
			//if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
		}

		//if (Input.GetKeyDown(KeyCode.Delete))
		//{
		//	Debug.Log(">>> delete key was pressed");
		//	Context.DictionaryManager.RemoveCurrentWord();
		//}
	}

	private bool _isEndEdit;
	private bool _isIgnoreNextOnValueChange;
	public void OnValueChanged(string text)
	{
		if (_isIgnoreNextOnValueChange)
		{
			_isIgnoreNextOnValueChange = false;
			return;
		}

		if (text.EndsWith("\n"))
		{
			_isEndEdit = true;
			_inputField.text = text.Remove(text.Length - 1);
			return;
		}

		var isLastSymbolWrong = DictManager.InputWord(text, _isEndEdit);
		if (isLastSymbolWrong)
		{
			_isIgnoreNextOnValueChange = true;
			_inputField.text = text.Remove(text.Length - 1);
		}
		_isEndEdit = false;
	}

	private void OnUpdateUI()
    {
        UpdateData(DictManager.CurrentWord);

        _textMasked.text = DictManager.Masked;
	}

	private void OnSetNewWord(Word word)
	{
		_inputField.text = string.Empty;
       UpdateData(word);
       _textMasked.text = DictManager.Masked;
	}

    private void UpdateData(Word word)
    {
		if (word == null)
			return;

        _textTranslation.text = word.Translation;
        _textExample.text = word.ExampleForView;
        _textType.text = string.IsNullOrEmpty(word.Type) ? string.Empty : word.Type.ToUpper();
        _wordProgressView.Progress = word.Ratio;
	}

	private void OnPrintDictionary(Dictionary dictionary)
	{
		//_textConsole.text = vocabulary.ToString();
	}

	private void OnDictionaryFinished(bool isFinished)
	{
		_checkPanel.SetActive(!isFinished);
		_dictFinishedPanel.SetActive(isFinished);
	}
}
