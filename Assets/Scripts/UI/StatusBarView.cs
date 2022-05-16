using TMPro;
using UnityEngine;
using WordMaster;

public class StatusBarView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;

	void Start()
	{
		Context.VocabularyManager.OnWordFinished += OnWordFinished;
		_text.text = string.Empty;
	}

	private void OnWordFinished(WordItem word)
	{
		_text.text = word.ToString();
	}
}
