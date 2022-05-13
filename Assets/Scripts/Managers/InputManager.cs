public class InputManager : BaseManager
{
	private TranslatePageView _view;
	private WordItem _currentWord;
	private bool _isAutoInput = true;

	public bool IsReversed { get; set; }

	public void SetView(TranslatePageView view)
	{
		_view = view;
	}

	public void OnValueChanged()
	{
		if (_view == null)
			return;

		UpdateMaskedText();
	}

	public void OnEndEdit()
	{
		return;

		if (_view == null)
			return;

		string textForCheck = _view.InputField;
		if (_isAutoInput && _currentWord.IsFullTranslation(textForCheck, IsReversed))
		{
			UpdateWord();
		}
		else
		{
			string translate = _currentWord.GetTranslation(IsReversed);
			_view.Masked = translate.SetColor("red");
		}
		_view.FocusInputField();
		string text = _view.InputField;
		_view.InputField = string.Empty;
		_view.InputField = text;
	}

	public void UpdateWord()
	{
		if (_view == null)
			return;

		if (_currentWord != null)
		{
			_currentWord.AnswerCorrect();
			_view.StatusBar = string.Format(_currentWord.ToString());
		}

		_currentWord = Context.VocabularyManager.Vocabulary.NextWord;

		_view.Translation = _currentWord.GetTranslation(IsReversed);
		_view.InputField = string.Empty;
		UpdateMaskedText();

		PrintVocabulary();
	}

	private void UpdateMaskedText()
	{
		if (_view == null)
			return;

		string textForCheck = _view.InputField;

		if (_currentWord.IsCorrectTranslation(textForCheck, IsReversed))
		{
			_view.Masked = _currentWord.GetMaskedText(textForCheck, IsReversed).SetColor("white");

			if (_isAutoInput && _currentWord.IsFullTranslation(textForCheck, IsReversed))
			{
				UpdateWord();
			}
		}
		else
		{
			string phrase = _currentWord.GetWord(IsReversed);
			_view.Masked = phrase.SetColor("red");
			_currentWord.AnswerWrong();
			PrintVocabulary();
		}
	}

	private void PrintVocabulary()
	{
		_view.Console = Context.VocabularyManager.Vocabulary.ToString();
	}
}