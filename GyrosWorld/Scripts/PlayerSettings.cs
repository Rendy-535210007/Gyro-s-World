using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSettings : MonoBehaviour
{
    public GameObject levelSelectionUI;
    public GameObject mainMenu;
    public TMP_InputField player1NameInputField;
    public TMP_InputField player2NameInputField;
    public TMP_InputField player3NameInputField;
    public TMP_InputField player4NameInputField;
    public TMP_InputField player5NameInputField;
    public TMP_InputField player6NameInputField;

    public void CancelSave()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("CurPlayer", 1);
        levelSelectionUI.SetActive(true);
        gameObject.SetActive(false);

        // Player 1
        if(player1NameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("NameP1", "Player 1");
            PlayerPrefs.SetFloat("ScoreP1", 0f);
        } else
        {
            PlayerPrefs.SetString("NameP1", player1NameInputField.text);
            PlayerPrefs.SetFloat("ScoreP1", 0f);
        }

        // Player 2
        if (player2NameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("NameP2", "");
            PlayerPrefs.SetFloat("ScoreP2", 0f);
        }
        else
        {
            PlayerPrefs.SetString("NameP2", player2NameInputField.text);
            PlayerPrefs.SetFloat("ScoreP2", 0f);
        }

        // Player 3
        if (player3NameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("NameP3", "");
            PlayerPrefs.SetFloat("ScoreP3", 0f);
        }
        else
        {
            PlayerPrefs.SetString("NameP3", player3NameInputField.text);
            PlayerPrefs.SetFloat("ScoreP3", 0f);
        }

        // Player 4
        if (player4NameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("NameP4", "");
            PlayerPrefs.SetFloat("ScoreP4", 0f);
        }
        else
        {
            PlayerPrefs.SetString("NameP4", player4NameInputField.text);
            PlayerPrefs.SetFloat("ScoreP4", 0f);
        }

        // Player 5
        if (player5NameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("NameP5", "");
            PlayerPrefs.SetFloat("ScoreP5", 0f);
        }
        else
        {
            PlayerPrefs.SetString("NameP5", player5NameInputField.text);
            PlayerPrefs.SetFloat("ScoreP5", 0f);
        }

        // Player 6
        if (player6NameInputField.text.Trim() == "")
        {
            PlayerPrefs.SetString("NameP6", "");
            PlayerPrefs.SetFloat("ScoreP6", 0f);
        }
        else
        {
            PlayerPrefs.SetString("NameP6", player6NameInputField.text);
            PlayerPrefs.SetFloat("ScoreP6", 0f);
        }
    }

    private void OnEnable()
    {
        player1NameInputField.text = PlayerPrefs.GetString("NameP1");
        player2NameInputField.text = PlayerPrefs.GetString("NameP2");
        player3NameInputField.text = PlayerPrefs.GetString("NameP3");
        player4NameInputField.text = PlayerPrefs.GetString("NameP4");
        player5NameInputField.text = PlayerPrefs.GetString("NameP5");
        player6NameInputField.text = PlayerPrefs.GetString("NameP6");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        player1NameInputField.text = "";
        player2NameInputField.text = "";
        player3NameInputField.text = "";
        player4NameInputField.text = "";
        player5NameInputField.text = "";
        player6NameInputField.text = "";
    }
}
