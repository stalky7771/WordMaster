using System;

namespace WordMaster
{
    [Serializable]
    public class ConfigurationManagerDto
    {
        public bool showWordLength;
        public bool showFirstLetter;
        public bool showCorrectWord;
        public bool isReversedWord;
        public bool showOptionsPanel;
        public string lastDictionaryFilePath;
        public string version;

        public ConfigurationManagerDto()
        {

        }

        public ConfigurationManagerDto(ConfigurationManager config)
        {
            showWordLength = config.ShowWordLength;
            showFirstLetter = config.ShowFirstLetter;
            showCorrectWord = config.ShowCorrectWord;
            isReversedWord = config.IsReversedWord;
            showOptionsPanel = config.ShowOptionsPanel;
            lastDictionaryFilePath = config.LastDictionaryFilePath;
            version = config.Version;
        }
    }
}