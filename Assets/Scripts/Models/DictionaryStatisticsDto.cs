using System;

namespace WordMaster
{
	[Serializable]
	public class DictionaryStatisticsDto
	{
		public int correctAnswer;
		public int wrongAnswer;
		public float time;
	}
}