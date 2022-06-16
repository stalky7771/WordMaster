using UnityEngine;

public class TabHolderView : MonoBehaviour
{
	[SerializeField] private GameObject _tabWordChecker;
	[SerializeField] private GameObject _tabLoadDictionary;

	private void Start()
	{
		OnShowCheckWords();
	}

	public void OnShowLoadDictionaries()
	{
		_tabWordChecker.SetActive(false);
		_tabLoadDictionary.SetActive(true);
	}

	public void OnShowCheckWords()
	{
		_tabWordChecker.SetActive(true);
		_tabLoadDictionary.SetActive(false);
	}
}