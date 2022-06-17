using UnityEngine;
using WordMaster;

public class MenuView : MonoBehaviour
{
	[SerializeField] private GameObject _console;

	public void OnClickTest()
	{
		Context.View?.ShowIcon();
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