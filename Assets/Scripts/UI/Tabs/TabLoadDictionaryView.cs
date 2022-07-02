using System.Collections.Generic;
using System.IO;
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
		var path = @"D:\_RESEARCH\UNITY\Dictionaries\"; // Application.dataPath
		var files = FileHelper.GetFiles(path);

		AddItems(files);
	}

	public void AddItems(List<string> filePath)
	{
		Clear();

		var counter = 0;
		filePath.ForEach(path =>
		{
			var item = Instantiate(_template).GetComponent<FilePathItem>();
			item.transform.SetParent(_root);
			item.gameObject.name = $"item{counter++}";
			item.gameObject.SetActive(true);

			var fileName = Path.GetFileNameWithoutExtension(path);

			item.Init(fileName, "", () =>
			{
				Context.DictionaryManager.LoadDictionary(path);
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
