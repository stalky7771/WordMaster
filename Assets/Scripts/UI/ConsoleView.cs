using TMPro;
using UnityEngine;
using WordMaster;

public class ConsoleView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	private DictionaryManager DictManager => Context.DictionaryManager;

	void OnEnable()
    {
		if (DictManager != null)
			DictManager.OnPrintDictionary += OnPrintDictionary;
	}

	void OnDisable()
	{
		if (DictManager != null)
			DictManager.OnPrintDictionary -= OnPrintDictionary;
	}

	private void OnPrintDictionary(Dictionary dictionary)
	{
		_text.text = dictionary.ToString();
	}
}
