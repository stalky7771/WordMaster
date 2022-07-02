using TMPro;
using UnityEngine;
using WordMaster;

public class ConsoleView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	private DictionaryManager DictManager => Context.DictionaryManager;

	private void OnEnable()
    {
		if (DictManager != null)
			DictManager.OnPrintDictionary += OnPrintDictionary;

        if (Context.DictionaryManager.Dictionary != null)
            OnPrintDictionary(Context.DictionaryManager.Dictionary);
    }

	private void OnDestroy()
	{
		if (DictManager != null)
			DictManager.OnPrintDictionary -= OnPrintDictionary;
	}

	private void OnPrintDictionary(Dictionary dictionary)
	{
		_text.text = dictionary.ToString();
	}
}
