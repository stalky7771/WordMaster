using TMPro;
using UnityEngine;
using WordMaster;

public class ConsoleView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	void Start()
    {
	    Context.DictionaryManager.OnPrintDictionary += OnPrintDictionary;
	}

	private void OnPrintDictionary(Dictionary dictionary)
	{
		_text.text = dictionary.ToString();
	}
}
