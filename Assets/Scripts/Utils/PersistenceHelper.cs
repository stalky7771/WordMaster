using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace WordMaster
{
	public class PersistenceHelper
	{
		public static void SaveToJson(string fileName, object dto)
		{
			var json = JsonUtility.ToJson(dto, true);
			File.WriteAllText(fileName, json);
		}

		public static T LoadFromJson<T>(string fileName) where T : class 
		{
			if (File.Exists(fileName) == false)
				return null;

			var json = File.ReadAllText(fileName);
			var dto = Deserialize<T>(json);

			return dto;
		}

		private static string Serialize(Object dto)
		{
			return JsonConvert.SerializeObject(dto, Formatting.Indented);
		}

		private static T Deserialize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
