using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WordMaster;

public class StatisticsView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textInfo;

	private void Awake()
	{
		Context.DictionaryManager.OnUpdateUi += OnUpdateUi;
	}

	private void OnUpdateUi()
	{
		if (Context.DictionaryManager.Dictionary == null)
			return;

		_textInfo.text = Context.DictionaryManager.Dictionary.Statistics.ToString();
	}
}