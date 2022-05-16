using TMPro;
using UnityEngine;
using WordMaster;

public class ConsoleView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	void Start()
    {
	    Context.VocabularyManager.OnPrintVocabulary += OnPrintVocabulary;
	}

	private void OnPrintVocabulary(Vocabulary vocabulary)
	{
		_text.text = vocabulary.ToString();
	}
}
