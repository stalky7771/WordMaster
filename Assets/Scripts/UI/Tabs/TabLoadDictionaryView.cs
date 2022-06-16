using System.Collections.Generic;
using UnityEngine;
using WordMaster;

public class TabLoadDictionaryView : MonoBehaviour
{
	[SerializeField] private GameObject _template;
	[SerializeField] private Transform _root;
	[SerializeField] private TabHolderView _tabHolderView;

	private void Awake()
	{
		_template.SetActive(false);
	}

	private void OnEnable()
	{
		ShowTable();
	}

	public void ShowTable()
	{
		var path = @"D:\DOWNLOAD\"; // Application.dataPath
		var files = FileHelper.GetFiles(path);

		AddItems(files);
	}

	public void AddItems(List<string> fileNames)
	{
		Clear();

		var counter = 0;
		fileNames.ForEach(fileName =>
		{
			var item = Object.Instantiate(_template).GetComponent<FilePathItem>();
			item.transform.SetParent(_root);
			item.gameObject.name = $"item{counter++}";
			item.gameObject.SetActive(true);

			item.Init(fileName, "", () =>
			{
				Context.DictionaryManager.LoadFromJson(fileName);
				_tabHolderView.OnShowCheckWords();
			});
		});
	}

	private void Clear()
	{
		var items = _root.GetComponentsInChildren<FilePathItem>();
		foreach (var item in items)
		{
			if (item.name != "template")
				Destroy(item.gameObject);
		}
	}
}
