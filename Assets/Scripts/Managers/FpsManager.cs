using System;
using UnityEngine;
using WordMaster;

public class FpsManager : BaseManager
{
	private double _cached;
	private int _fpsCached;

	public event Action<string> OnUpdate;

	public override void Update()
    {
		var time = Time.realtimeSinceStartupAsDouble;
		var delta = time - _cached;
		_cached = time;

		if (delta > 0)
		{
			int fps = Mathf.CeilToInt((float)(1 / delta));
			if (Mathf.Abs(fps - _fpsCached) > 3)
			{
				_fpsCached = fps;
			}
			OnUpdate?.Invoke($"fps:{_fpsCached}");
		}
	}
}
