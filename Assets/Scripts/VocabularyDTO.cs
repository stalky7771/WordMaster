using System;
using System.Collections.Generic;

[Serializable]
public class VocabularyDTO
{
	public int version;
	public string name;
	public List<WordItemDTO> words;

	public VocabularyDTO()
	{

	}

	public VocabularyDTO(Vocabulary vocabulary)
	{
		version = vocabulary.Version;
		name    = vocabulary.Name;

		words = new List<WordItemDTO>();
		vocabulary.Words.ForEach(w => words.Add(new WordItemDTO(w)));
	}
}