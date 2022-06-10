using TMPro;
using UnityEngine;
using WordMaster;

public class ConsoleView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	void Start()
    {
	    Context.DictionaryManager.OnPrintVocabulary += OnPrintVocabulary;
	}

	private void OnPrintVocabulary(Dictionary vocabulary)
	{
		_text.text = vocabulary.ToString();
	}
}
