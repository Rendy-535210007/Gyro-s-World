using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    public TextMeshProUGUI playerName1;
    public TextMeshProUGUI playerName2;
    public TextMeshProUGUI playerName3;
    public TextMeshProUGUI playerName4;
    public TextMeshProUGUI playerName5;
    public TextMeshProUGUI playerName6;
    public TextMeshProUGUI playerScore1;
    public TextMeshProUGUI playerScore2;
    public TextMeshProUGUI playerScore3;
    public TextMeshProUGUI playerScore4;
    public TextMeshProUGUI playerScore5;
    public TextMeshProUGUI playerScore6;

    // Start is called before the first frame update
    void Start()
    {
        playerName1.text = PlayerPrefs.GetString("NameP1") + " :";
        playerScore1.text = PlayerPrefs.GetFloat("ScoreP1").ToString("F3");

        if (PlayerPrefs.GetString("NameP2") == "")
        {
            playerName2.text = "";
            playerScore2.text = "";
        }
        else
        {
            playerName2.text = PlayerPrefs.GetString("NameP2") + " :";
            playerScore2.text = PlayerPrefs.GetFloat("ScoreP2").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP3") == "")
        {
            playerName3.text = "";
            playerScore3.text = "";
        }
        else
        {
            playerName3.text = PlayerPrefs.GetString("NameP3") + " :";
            playerScore3.text = PlayerPrefs.GetFloat("ScoreP3").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP4") == "")
        {
            playerName4.text = "";
            playerScore4.text = "";
        }
        else
        {
            playerName4.text = PlayerPrefs.GetString("NameP4") + " :";
            playerScore4.text = PlayerPrefs.GetFloat("ScoreP4").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP5") == "")
        {
            playerName5.text = "";
            playerScore5.text = "";
        }
        else
        {
            playerName5.text = PlayerPrefs.GetString("NameP5") + " :";
            playerScore5.text = PlayerPrefs.GetFloat("ScoreP5").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP6") == "")
        {
            playerName6.text = "";
            playerScore6.text = "";
        }
        else
        {
            playerName6.text = PlayerPrefs.GetString("NameP6") + " :";
            playerScore6.text = PlayerPrefs.GetFloat("ScoreP6").ToString("F3");
        }
    }

    private void Awake()
    {
        playerName1.text = PlayerPrefs.GetString("NameP1") + " :";
        playerScore1.text = PlayerPrefs.GetFloat("ScoreP1").ToString("F3");

        if (PlayerPrefs.GetString("NameP2") == "")
        {
            playerName2.text = "";
            playerScore2.text = "";
        }
        else
        {
            playerName2.text = PlayerPrefs.GetString("NameP2") + " :";
            playerScore2.text = PlayerPrefs.GetFloat("ScoreP2").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP3") == "")
        {
            playerName3.text = "";
            playerScore3.text = "";
        }
        else
        {
            playerName3.text = PlayerPrefs.GetString("NameP3") + " :";
            playerScore3.text = PlayerPrefs.GetFloat("ScoreP3").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP4") == "")
        {
            playerName4.text = "";
            playerScore4.text = "";
        }
        else
        {
            playerName4.text = PlayerPrefs.GetString("NameP4") + " :";
            playerScore4.text = PlayerPrefs.GetFloat("ScoreP4").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP5") == "")
        {
            playerName5.text = "";
            playerScore5.text = "";
        }
        else
        {
            playerName5.text = PlayerPrefs.GetString("NameP5") + " :";
            playerScore5.text = PlayerPrefs.GetFloat("ScoreP5").ToString("F3");
        }

        if (PlayerPrefs.GetString("NameP6") == "")
        {
            playerName6.text = "";
            playerScore6.text = "";
        }
        else
        {
            playerName6.text = PlayerPrefs.GetString("NameP6") + " :";
            playerScore6.text = PlayerPrefs.GetFloat("ScoreP6").ToString("F3");
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
