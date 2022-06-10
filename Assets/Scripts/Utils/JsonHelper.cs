using Newtonsoft.Json;

namespace WordMaster
{
	internal class JsonHelper
	{
		public static string Serialize(DictionaryDTO dto)
		{
			return JsonConvert.SerializeObject(dto, Formatting.Indented);
		}

		public static DictionaryDTO Deserialize(string json)
		{
			return JsonConvert.DeserializeObject<DictionaryDTO>(json);
		}
	}
}
