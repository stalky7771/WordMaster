using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FilePathItem : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _textPath;
	[SerializeField] private TextMeshProUGUI _textWordsCount;
	[SerializeField] private Button _button;

	public void Init(string textPath,
		string wordsCount,
		UnityAction onClick)
	{
		_textPath.text = textPath;
		_textWordsCount.text = wordsCount;
		_button.onClick.AddListener(onClick);
	}
}
