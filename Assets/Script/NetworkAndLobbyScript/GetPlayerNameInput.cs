using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetPlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    public static string DisplayName { get; private set; }

    private const string PlayerPrefabNameKey = "PlayerName";

    private void start()
    {
        continueButton.interactable = false;
        SetUpInputField();
    }
    private void SetUpInputField()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefabNameKey)) { return; }
        string defaultName = PlayerPrefs.GetString(PlayerPrefabNameKey);
        nameInputField.text = defaultName;
        SetPlayerName(defaultName);
    }
    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name);

    }
    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;
        PlayerPrefs.SetString(PlayerPrefabNameKey, DisplayName);
    }
}
