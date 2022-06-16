using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileHelper : MonoBehaviour
{
	public static List<string> GetFiles(string root)
	{
		var result = new List<string>();
		
		if (Directory.Exists(root) == false)
		{
			return result;
		}

		return Directory.GetFiles(root, "*.dict").ToList();
	}
}
