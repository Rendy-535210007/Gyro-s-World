using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    int levelRandomize = 0;
    public GameObject mainMenu;

    public void QuickDraw()
    {
        SceneManager.LoadScene("QuickDraw");
    }
    public void CrackTheVault()
    {
        SceneManager.LoadScene("CrackTheVault");
    }
    public void DrinkContest()
    {
        SceneManager.LoadScene("DrinkContest");
    }
    public void Paparazo()
    {
        SceneManager.LoadScene("Paparazo");
    }
    public void FishingManiac()
    {
        SceneManager.LoadScene("FishingManiac");
    }
    public void Cheers()
    {
        SceneManager.LoadScene("Cheers");
    }
    public void HighStriker()
    {
        SceneManager.LoadScene("HighStriker");
    }
    public void AnswerThePhone()
    {
        SceneManager.LoadScene("AnswerThePhone");
    }
    public void Skeeroscope()
    {
        SceneManager.LoadScene("Skeeroscope");
    }
    public void SignalFlag()
    {
        SceneManager.LoadScene("SignalFlag");
    }
    public void GyropeWalker()
    {
        SceneManager.LoadScene("GyropeWalker");
    }
    public void Randomize()
    {
        levelRandomize = Random.Range(1, 12);

        if(levelRandomize == 1)
        {
            QuickDraw();
        } else if(levelRandomize == 2)
        {
            CrackTheVault();
        } else if (levelRandomize == 3)
        {
            DrinkContest();
        } else if (levelRandomize == 4)
        {
            Paparazo();
        } else if (levelRandomize == 5)
        {
            FishingManiac();
        } else if (levelRandomize == 6)
        {
            Cheers();
        } else if (levelRandomize == 7)
        {
            HighStriker();
        } else if (levelRandomize == 8)
        {
            AnswerThePhone();
        } else if (levelRandomize == 9)
        {
            Skeeroscope();
        } else if (levelRandomize == 10)
        {
            SignalFlag();
        } else if (levelRandomize == 11)
        {
            GyropeWalker();
        }
    }

    public void BackToMM()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
