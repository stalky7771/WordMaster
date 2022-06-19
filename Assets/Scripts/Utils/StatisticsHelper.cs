using System.Text;

namespace Assets.Scripts.Utils
{
	public class StatisticsHelper
	{
		public int CorrectAnswer { get; private set; }
		public int WrongAnswer { get; private set; }

		public void IncrementCorrectAnswer()
		{
			CorrectAnswer++;
		}

		public void IncrementWrongAnswer()
		{
			WrongAnswer++;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Correct: ");
			sb.Append(CorrectAnswer.ToString().SetColor("green"));
			sb.Append(", Wrong: ");
			sb.Append(WrongAnswer.ToString().SetColor("red"));
			return sb.ToString();
		}

		public void Clear()
		{
			CorrectAnswer = 0;
			WrongAnswer = 0;
		}
	}
}
