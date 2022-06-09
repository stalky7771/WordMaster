namespace WordMasterEditor
{
	internal class Context
	{
		public static DictionaryManager DictionaryManager;
		
		public static void Init()
		{
			DictionaryManager = new DictionaryManager();
		}
	}
}
