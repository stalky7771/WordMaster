using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WordMaster;

public class WordProgressView : MonoBehaviour
{
	[SerializeField] private Image _imageGreen;
	[SerializeField] private Image _imageRed;
	[SerializeField] private TextMeshProUGUI _text;

	public int Progress
	{
		set
		{
			if (value >= 0)
			{
				ShowImageGreen(true);
				_imageGreen.fillAmount = (float)value / Word.MAX_RATIO;
			}
			else
			{
				ShowImageGreen(false);
				_imageRed.fillAmount = (float)value / Word.MIN_RATIO;
			}

			_text.text = value.ToString();
		}
	}

	private void ShowImageGreen(bool flag)
	{
		_imageGreen.gameObject.SetActive(flag);
		_imageRed.gameObject.SetActive(!flag);
	}
}
