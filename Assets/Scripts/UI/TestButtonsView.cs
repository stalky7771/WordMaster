using UnityEngine;
using WordMaster;

public class TestButtonsView : MonoBehaviour
{
	public void OnClickTest()
	{
		Debug.Log(">>> OnClickTest");
		
	}

	public void OnClickLoad()
	{
		Debug.Log(">>> OnClickLoadFromJson");
		//Context.DictionaryManager.LoadFromJson();
	}

	public void OnClickSave()
	{
		Context.DictionaryManager.SaveToJson();
	}

	public void OnClickRemoveWord()
	{
		Context.DictionaryManager.RemoveCurrentWord();
	}
}