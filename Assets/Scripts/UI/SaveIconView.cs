using UnityEngine;

public class SaveIconView : MonoBehaviour
{
	public void Show()
	{
		gameObject.SetActive(true);
	}
	
	public void OnFinished()
	{
		gameObject.SetActive(false);
	}
}
