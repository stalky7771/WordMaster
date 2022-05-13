﻿using System;

[Serializable]
public class WordItemDTO
{
	public string word;
	public string translation;
	public string transkription;
	public int ratio;
	public int viewed;

	public WordItemDTO()
	{

	}

	public WordItemDTO(WordItem wordItem)
	{
		word = wordItem.GetWord();
		translation = wordItem.GetTranslation();
		transkription = wordItem.Transcription;
		ratio = wordItem.Ratio;
		viewed = wordItem.Viewed;
	}
}