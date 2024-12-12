using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void Replay()
    {
        int getNextPlayer = PlayerPrefs.GetInt("CurPlayer") + 1;

        if (PlayerPrefs.GetString("NameP" + getNextPlayer.ToString()).Trim() != "")
        {
            PlayerPrefs.SetInt("CurPlayer", getNextPlayer);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("ResultMenu");
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
