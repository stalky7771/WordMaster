using TMPro;
using UnityEngine;

public class Version
{
	const string KEY_NAME = "version";

	public string Ver { get; private set; }

	public Version()
	{
		Ver = PlayerPrefs.GetString(KEY_NAME, "0.0.0.0");
		string[] numbers = Ver.Split('.');
		int playModeCount = int.Parse(numbers[3]);
		playModeCount++;
		string newVersion = $"{numbers[0]}.{numbers[1]}.{numbers[2]}.{playModeCount}";
		PlayerPrefs.SetString(KEY_NAME, newVersion);
	}
}