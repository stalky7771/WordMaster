using System;
using UnityEngine;

namespace WordMaster
{
    public class ConfigurationManager : BaseManager
    {
        private const string PLAYER_PREFERENCES_KEY = "WordMasterConfiguration";

        public event Action OnUpdate;

        private bool _showWordLength;
        private bool _showFirstLetter;
        private bool _showCorrectWord;
        private bool _showOptionsPanel;
		private bool _isReversedWord;
        private string _lastDictionaryFilePath;

		public string Version { get; private set; }

        public bool ShowWordLength
        {
            get => _showWordLength;
            set
            {
                _showWordLength = value;
				Save();
				OnUpdate?.Invoke();
            }
        }

        public bool ShowFirstLetter
        {
            get => _showFirstLetter;
			set
			{
                _showFirstLetter = value;
				Save();
                OnUpdate?.Invoke();
            }
        }

        public bool ShowCorrectWord
        {
            get => _showCorrectWord;
            set
            {
                _showCorrectWord = value;
				Save();
                OnUpdate?.Invoke();
            }
        }

        public bool IsReversedWord
        {
            get => _isReversedWord;
            set
            {
                _isReversedWord = value;
				Save();
                OnUpdate?.Invoke();
            }
        }

        public bool ShowOptionsPanel
        {
            get => _showOptionsPanel;
            set
            {
                _showOptionsPanel = value;
				Save();
            }
        }

        public string LastDictionaryFilePath
        {
            get => _lastDictionaryFilePath;
            set
            {
                _lastDictionaryFilePath = value;
				Save();
            }
        }

		public override void InitAwake()
        {
			Load();
        }

		public void Load()
        {
            var json = PersistenceHelper.LoadFromPlayerPreference(PLAYER_PREFERENCES_KEY);

            if (string.IsNullOrEmpty(json) == false)
            {
                var dto = PersistenceHelper.LoadFromJson<ConfigurationManagerDto>(json);
				Init(dto);
            }
        }

        public void Save()
        {
            var dto = new ConfigurationManagerDto(this);
            var json = PersistenceHelper.SaveToJson(dto);
			PersistenceHelper.SaveToPlayerPreference(PLAYER_PREFERENCES_KEY, json);
        }

        private void Init(ConfigurationManagerDto dto)
        {
            ShowWordLength = dto.showWordLength;
            ShowFirstLetter = dto.showFirstLetter;
            ShowCorrectWord = dto.showCorrectWord;
            IsReversedWord = dto.isReversedWord;
            ShowOptionsPanel = dto.showOptionsPanel;
            LastDictionaryFilePath = dto.lastDictionaryFilePath;
            Version = dto.version;

            if (Application.isEditor)
            {
                Version = UpdateUnityEditorVersion(Version);
                Save();
            }
        }

        private string UpdateUnityEditorVersion(string ver)
        {
            if (string.IsNullOrEmpty(ver))
            {
                ver = "0.0.0.423";
            }
            string[] numbers = ver.Split('.');
            int playModeCount = int.Parse(numbers[3]);

			if (Application.isEditor)
                playModeCount++;

            return $"{numbers[0]}.{numbers[1]}.{numbers[2]}.{playModeCount}";
        }
    }
}