using UnityEngine;
using WordMaster;

public class MenuView : MonoBehaviour
{
	[SerializeField] private GameObject _console;

	public void OnClickTest()
	{
		string alphabet =
			"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzA����Ũ����������������������������������������������������������.,!? *'- 0123456789[]()?a???????3?";
		string text = "�, ����� (� �������)";
		for (var i = 0; i < text.Length; i++)
		{
			var simbol = text[i];
			if (alphabet.Contains(simbol) == false)
				Debug.LogWarning(">>> " + text[i]);
		}
	}

	public void OnClickSave()
	{
		Context.DictionaryManager.SaveToJson();
	}

	public void OnClickRemoveWord()
	{
		Context.DictionaryManager.RemoveCurrentWord();
	}

	public void OnClickShowConsole()
	{
		_console.SetActive(!_console.activeSelf);
		if (_console.activeSelf)
			Context.DictionaryManager.PrintDictionary();
	}
}