using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WordMaster;

public class WordCheckingView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textTranslation;
	[SerializeField] private TextMeshProUGUI _textMasked;
	[SerializeField] private TextMeshProUGUI _textDescription;
	[SerializeField] private TMP_InputField _inputField;

	[SerializeField] private GameObject _checkPanel;
	[SerializeField] private GameObject _dictFinishedPanel;

	[SerializeField] private WordStatisticsView _wordStatisticsView;

	public string Translation
	{
		set => _textTranslation.text = value;
	}

	public string Masked
	{
		set => _textMasked.text = value;
	}

	public string Description
	{
		set => _textDescription.text = value;
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
	public void OnValueChanged(string text)
	{
		if (text.EndsWith("\n"))
		{
			_isEndEdit = true;
			_inputField.text = text.Remove(text.Length - 1);
			return;
		}

		Context.DictionaryManager.InputWord(text, _isEndEdit);
		_isEndEdit = false;
	}

	private void OnUpdateUI()
	{
		Translation = Context.DictionaryManager.CurrentWord.Translation;
		Masked = Context.DictionaryManager.Masked;
		Description = Context.DictionaryManager.CurrentWord.DescriptionWithCensure;
		_wordStatisticsView.Progress = Context.DictionaryManager.CurrentWord.Ratio;
	}

	private void OnSetNewWord(Word word)
	{
		_inputField.text = string.Empty;
		Translation = word.Translation;
		Description = word.DescriptionWithCensure;
		Masked = Context.DictionaryManager.Masked;
		_wordStatisticsView.Progress = Context.DictionaryManager.CurrentWord.Ratio;
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
