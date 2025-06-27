﻿using MightyAdventures.CharacterSystem;
using MightyAdventures.SceneManagement;
using MightyAdventures.StatSystem.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MightyAdventures.MainMenu
{
    public class CharacterSelection : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterData playerCharacterData;
        [SerializeField] private PlayerCharacterExperienceData playerCharacterExperienceData;
        [SerializeField] private StatTextPreview statTextPreview;
        [SerializeField] private Transform characterParent;
        [SerializeField] private float characterPrefabScale = 2f;
        [SerializeField] private Button selectButton;

        private PlayerCharacterTemplate _playerCharacterTemplate;

        public void Initialize(PlayerCharacterTemplate characterTemplate)
        {
            _playerCharacterTemplate = characterTemplate;
            var character = Instantiate(_playerCharacterTemplate.Prefab, characterParent);
            character.transform.localScale = Vector3.one * characterPrefabScale;
            statTextPreview.Initialize(_playerCharacterTemplate.PlayerCharacterStats);
        }

        private void OnSelectButtonClicked()
        {
            var targetExperience = playerCharacterExperienceData.GetExperienceCost(2);
            playerCharacterData.InitializePlayerCharacter(_playerCharacterTemplate, targetExperience);
            SceneLoader.Instance.LoadGameScene();
        }

        #region MonoBehaviour Methods

        private void OnEnable()
        {
            selectButton.onClick.AddListener(OnSelectButtonClicked);
        }

        private void OnDisable()
        {
            selectButton.onClick.RemoveListener(OnSelectButtonClicked);
        }

        #endregion
    }
}