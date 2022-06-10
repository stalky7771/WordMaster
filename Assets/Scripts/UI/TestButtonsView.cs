using UnityEngine;
using WordMaster;

public class TestButtonsView : MonoBehaviour
{
	public void OnClickTest()
	{
		Debug.Log(">>> OnClickTest");
		
	}

	public void OnClickLoadFromCSV()
	{
		Debug.Log(">>> OnClickLoadFromCSV");
		//DictionaryManager.LoadFromCSV();
	}

	public void OnClickLoadFromJson()
	{
		Debug.Log(">>> OnClickLoadFromJson");
		//Context.DictionaryManager.LoadFromJson();
	}

	public void OnClickSaveToJson()
	{
		//Debug.Log(">>> OnClickSaveToJson");
		Context.DictionaryManager.SaveToJson();
	}
}