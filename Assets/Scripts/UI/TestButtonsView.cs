using UnityEngine;

public class TestButtonsView : MonoBehaviour
{
	public void OnClickTest()
	{
		Debug.Log(">>> OnClickTest");
	}

	public void OnClickDefaultDictionary()
	{
		//Debug.Log(">>> OnClickDefaultDictionary");
		Context.VocabularyManager.SetDefaultVacabulary();
	}

	public void OnClickLoadFromCSV()
	{
		Debug.Log(">>> OnClickLoadFromCSV");
		//VocabularyManager.LoadFromCSV();
	}

	public void OnClickLoadFromJson()
	{
		Debug.Log(">>> OnClickLoadFromJson");
		//Context.VocabularyManager.LoadFromJson();
	}

	public void OnClickSaveToJson()
	{
		//Debug.Log(">>> OnClickSaveToJson");
		Context.VocabularyManager.SaveToJson();
	}
}
