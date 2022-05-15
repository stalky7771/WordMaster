using TMPro;
using UnityEngine;

public class VersionView : MonoBehaviour
{
	private bool _isInit;

	[SerializeField] private TextMeshProUGUI _text;
	
	void Awake()
	{
		if (_isInit)
			return;

		_isInit = true;

		const string KEY_NAME = "version";

		string version = PlayerPrefs.GetString(KEY_NAME, "0.0.0.0");
		_text.text = version;

		string[] numbers = version.Split('.');
		int playModeCount = int.Parse(numbers[3]);
		playModeCount++;
		string newVersion = $"{numbers[0]}.{numbers[1]}.{numbers[2]}.{playModeCount}";
		PlayerPrefs.SetString(KEY_NAME, newVersion);
	}
}