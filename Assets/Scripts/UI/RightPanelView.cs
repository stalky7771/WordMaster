using UnityEngine;
using WordMaster;

public class RightPanelView : MonoBehaviour
{
	[SerializeField] private GameObject _rightPanel;
	[SerializeField] private Transform _buttonShowRightPanel;
	
	private void Start()
	{
		ShowPanel(Context.Options.IsShowRightPanel);
	}

	public void OnClickToggleRightPanel()
	{
		Context.Options.IsShowRightPanel = !Context.Options.IsShowRightPanel;
		ShowPanel(Context.Options.IsShowRightPanel);
	}

	private void ShowPanel(bool flag)
	{
		_rightPanel.SetActive(flag);
		_buttonShowRightPanel.localScale = new Vector3(flag ? -1 : 1, 1, 1);
	}
}