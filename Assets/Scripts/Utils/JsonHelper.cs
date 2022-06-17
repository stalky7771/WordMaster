using Newtonsoft.Json;

namespace WordMaster
{
	internal class JsonHelper
	{
		public static string Serialize(DictionaryDto dto)
		{
			return JsonConvert.SerializeObject(dto, Formatting.Indented);
		}

		public static DictionaryDto Deserialize(string json)
		{
			return JsonConvert.DeserializeObject<DictionaryDto>(json);
		}
	}
}
