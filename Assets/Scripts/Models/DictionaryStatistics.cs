using System.Text;

namespace WordMaster
{
	public class DictionaryStatistics
	{
		public int CorrectAnswers { get; private set; }
		public int WrongAnswers { get; private set; }
		public int CorrectAnswersInSession { get; private set; }
		public int WrongAnswersInSession { get; private set; }
		public float Time { get; private set; }
		public Dictionary Dictionary { get; private set; }

		public DictionaryStatistics()
		{

		}

		public DictionaryStatistics(DictionaryStatisticsDto dto, Dictionary dictionary)
		{
			if (dto != null)
			{
				CorrectAnswers = dto.correctAnswer;
				WrongAnswers = dto.wrongAnswer;
				Time = dto.time;
			}
			
			Dictionary = dictionary;
		}

		public void IncrementCorrectAnswer()
		{
			CorrectAnswers++;
			CorrectAnswersInSession++;
		}

		public void IncrementWrongAnswer()
		{
			WrongAnswers++;
			WrongAnswersInSession++;
		}

		public void AddDeltaTime(float deltaTime)
		{
			Time += deltaTime;
		}

        public void ResetTime()
        {
            Time = 0;
        }

		public DictionaryStatisticsDto GetDto()
		{
			var dto = new DictionaryStatisticsDto
			{
				correctAnswer = CorrectAnswers,
				wrongAnswer = WrongAnswers,
				time = Time
			};

			return dto;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			
			sb.Append("Correct: ");
			sb.Append(CorrectAnswersInSession.ToString().SetColor("green"));
			sb.Append("/");
			sb.Append(CorrectAnswers.ToString());
			sb.Append(", ");

			sb.Append("Wrong: ");
			sb.Append(WrongAnswersInSession.ToString().SetColor("red"));
			sb.Append("/");
			sb.Append(WrongAnswers.ToString());

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
			CorrectAnswersInSession = 0;
			WrongAnswersInSession = 0;
		}
	}
}
