using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordMaster
{
	public class FileHelper
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
}