using UnityEngine;
using WordMaster;

public class MainMenuView : MonoBehaviour
{
	[SerializeField] private GameObject _console;

	public void OnClickTest()
	{
		Debug.Log(">>> OnClickTest");
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
	}
}