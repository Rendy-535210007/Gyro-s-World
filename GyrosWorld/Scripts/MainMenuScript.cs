using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject LevelSelection;
    public GameObject playerSettings;
    public Toggle languageCheckbox;

    private void Start()
    {
        PlayerPrefs.SetInt("CurPlayer", 1);

        if(PlayerPrefs.GetInt("Language") == 0 || PlayerPrefs.GetInt("Language") == null)
        {
            PlayerPrefs.SetInt("Language", 0);
            languageCheckbox.isOn = false;
        }else
        {
            languageCheckbox.isOn = true;
        }
    }

    private void Awake()
    {
        PlayerPrefs.SetInt("CurPlayer", 1);
    }

    public void PlayGame()
    {
        if (PlayerPrefs.GetString("NameP1") == "")
        {
            PlayerPrefs.SetString("NameP1", "Player 1");
        }

        LevelSelection.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PlayerSettings()
    {
        playerSettings.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeLanguage()
    {
        if(languageCheckbox.isOn)
        {
            PlayerPrefs.SetInt("Language", 1);
        } else
        {
            PlayerPrefs.SetInt("Language", 0);
        }
    }
}
