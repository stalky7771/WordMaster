using UnityEngine;
using WordMaster;

public class MenuView : MonoBehaviour
{
	[SerializeField] private GameObject _console;

	public void OnClickTest()
	{
		
	}

	public void OnClickSave()
	{
		Context.DictionaryManager.SaveDictionary();
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

    public void OnClickResetProgress()
    {
		Context.DictionaryManager.ResetProgress();
    }
}