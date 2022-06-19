namespace WordMaster
{
	public static class StringExtensions
	{
		public static string SetColor(this string str, string color)
		{
			return string.Format("<color={0}>{1}</color>", color, str);
		}

		public static string ToMonoSpace(this string str)
		{
			return "<mspace=.6em>" + str + "</mspace >";
		}
	}
}
