using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WordMaster;

public class StatisticsView : MonoBehaviour
{
	[SerializeField] private Image _image;
	[SerializeField] private TextMeshProUGUI _textProgress;
	[SerializeField] private TextMeshProUGUI _textCommonInfo;

	private void Start()
	{
		Context.DictionaryManager.OnSetNewWord += OnSetNewWord;
	}

	private void OnSetNewWord(Word obj)
	{
		if (Context.DictionaryManager.Dictionary == null)
			return;

		var rate = Context.DictionaryManager.Dictionary.CompleteRatio;
		_image.fillAmount = rate;
		_textProgress.text = rate.ToString("0.000") + "%";

		_textCommonInfo.text = Context.DictionaryManager.Statistics.ToString();
	}
}
