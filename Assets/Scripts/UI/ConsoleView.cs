using TMPro;
using UnityEngine;
using WordMaster;

public class ConsoleView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	void OnEnable()
    {
	    Context.DictionaryManager.OnPrintDictionary += OnPrintDictionary;
	}

	void OnDisable()
	{
		Context.DictionaryManager.OnPrintDictionary -= OnPrintDictionary;
	}

	private void OnPrintDictionary(Dictionary dictionary)
	{
		_text.text = dictionary.ToString().ToMonoSpace();
	}
}
