using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace WordMaster
{
	public class PersistenceHelper
	{
		public static string SaveToJson(object dto)
		{
			return JsonConvert.SerializeObject(dto, Formatting.Indented);
        }

        public static void WriteToFile(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
		}

		public static T LoadFromJson<T>(string json) where T : class 
		{
            return Deserialize<T>(json);
		}

        public static string ReadFromFile(string fileName)
        {
            return File.Exists(fileName) == false ? null : File.ReadAllText(fileName);
        }

		private static string Serialize(Object dto)
		{
			return JsonConvert.SerializeObject(dto, Formatting.Indented);
		}

		private static T Deserialize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

        public static string LoadFromPlayerPreference(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public static void SaveToPlayerPreference(string key, string text)
        {
			PlayerPrefs.SetString(key, text);
        }
	}
}
