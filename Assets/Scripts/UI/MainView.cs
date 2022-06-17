using UnityEngine;
using WordMaster;

public class MainView : MonoBehaviour
{
	[SerializeField] private SaveIconView _saveIcon;

	private void Start()
	{
		Context.SetView(this);
		Context.DictionaryManager.OnSaveDictionary += OnSaveDictionary;
	}

	public void ShowIcon()
	{
		_saveIcon.Show();
	}

	private void OnSaveDictionary()
	{
		ShowIcon();
	}
}
