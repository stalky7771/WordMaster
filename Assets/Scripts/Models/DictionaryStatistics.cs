using System.Text;

namespace WordMaster
{
	public class DictionaryStatistics
	{
		public int CorrectAnswer { get; private set; }
		public int WrongAnswer { get; private set; }
		public int CorrectAnswerInSession { get; private set; }
		public int WrongAnswerInSession { get; private set; }
		public float Time { get; private set; }
		public Dictionary Dictionary { get; private set; }

		public DictionaryStatistics()
		{

		}

		public DictionaryStatistics(DictionaryStatisticsDto dto, Dictionary dictionary)
		{
			if (dto != null)
			{
				CorrectAnswer = dto.correctAnswer;
				WrongAnswer = dto.wrongAnswer;
				Time = dto.time;
			}
			
			Dictionary = dictionary;
		}

		public void IncrementCorrectAnswer()
		{
			CorrectAnswer++;
			CorrectAnswerInSession++;
		}

		public void IncrementWrongAnswer()
		{
			WrongAnswer++;
			WrongAnswerInSession++;
		}

		public void AddDeltaTime(float deltaTime)
		{
			Time += deltaTime;
		}

		public DictionaryStatisticsDto GetDto()
		{
			var dto = new DictionaryStatisticsDto
			{
				correctAnswer = CorrectAnswer,
				wrongAnswer = WrongAnswer,
				time = Time
			};

			return dto;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			
			sb.Append("Correct: ");
			sb.Append(CorrectAnswerInSession.ToString().SetColor("green"));
			sb.Append("/");
			sb.Append(CorrectAnswer.ToString());
			sb.Append(", ");

			sb.Append("Wrong: ");
			sb.Append(WrongAnswerInSession.ToString().SetColor("red"));
			sb.Append("/");
			sb.Append(WrongAnswer.ToString());

			if (Dictionary != null)
			{
				sb.Append(", ");
				sb.Append(Dictionary.FinishedWords);

				sb.Append(", ");
				sb.Append(Dictionary.Progress);
			}

			return sb.ToString();
		}

		public void Clear()
		{
			CorrectAnswerInSession = 0;
			WrongAnswerInSession = 0;
		}
	}
}
