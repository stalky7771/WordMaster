using TMPro;
using UnityEngine;
using WordMaster;

public class StatusBarView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _leftText;
	[SerializeField] private TextMeshProUGUI _middleText;
	[SerializeField] private TextMeshProUGUI _rightText;

	public string RightText { set => _rightText.text = value; }
	public string LeftText { set => _leftText.text = value; }
	public string MiddleText { set => _middleText.text = value; }

	private void Start()
	{
		RightText = string.Empty;
		MiddleText = string.Empty;
		LeftText = string.Empty;

		Context.DictionaryManager.OnWordFinished += OnWordFinished;
		Context.FpsManager.OnUpdate += OnUpdateFps;

		RightText = Context.Config.Version;
	}

	private void Update()
	{
		if (Context.DictionaryManager.Dictionary != null)
			LeftText = Context.DictionaryManager.Dictionary.TimeToString;
	}

	private void OnWordFinished(Word word)
	{
		LeftText = word.ToString();
	}

	private void OnUpdateFps(string fps)
	{
		MiddleText = fps;
	}
}
