using TMPro;
using UnityEngine;

public class FpsCounterView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;
	private double _cached;
	private int _fpsCached;

	private void Start()
	{
		

	}

    private void Update()
    {
		double time = Time.realtimeSinceStartupAsDouble;
		double delta = time - _cached;
		_cached = time;

		if (delta > 0)
		{
			int fps = Mathf.CeilToInt((float)(1 / delta));
			if (Mathf.Abs(fps - _fpsCached) > 3)
			{
				_fpsCached = fps;
			}
			_text.text = $"fps:{_fpsCached}";
		}
    }
}
