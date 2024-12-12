using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NewLevelSelection : MonoBehaviour
{
    public GameObject mainMenu;
    int curGameSelected = 1;
    //public GameObject prevUI;
    //public GameObject nextUI;
    public Image prevGameImg;
    public TextMeshProUGUI prevGameTitle;
    public Image curGameImg;
    public TextMeshProUGUI curGameTitle;
    public Image nextGameImg;
    public TextMeshProUGUI nextGameTitle;
    public Sprite AnswerThePhone;
    public Sprite Cheers;
    public Sprite CrackTheVault;
    public Sprite DrinkContest;
    public Sprite FishingManiac;
    public Sprite GyropeWalker;
    public Sprite HighStriker;
    public Sprite Paparazo;
    public Sprite QuickDraw;
    public Sprite SignalFlag;
    public Sprite Skeeroscope;
    public Sprite Random;

    // Start is called before the first frame update
    void Start()
    {
        curGameSelected = 1;
    }

    public void prevGame()
    {
        if(curGameSelected > 1)
        {
            curGameSelected--;
            setUIFunc();
        } else
        {
            curGameSelected = 12;
            setUIFunc();
        }
    }

    public void nextGame()
    {
        if (curGameSelected < 12)
        {
            curGameSelected++;
            setUIFunc();
        }
        else
        {
            curGameSelected = 1;
            setUIFunc();
        }
    }

    void setUIFunc()
    {
        /*
        if (curGameSelected <= 1)
        {
            prevUI.SetActive(false);
        } else
        {
            prevUI.SetActive(true);
        }

        if (curGameSelected >= 12)
        {
            nextUI.SetActive(false);
        }
        else
        {
            nextUI.SetActive(true);
        }
        */

        switch(curGameSelected)
        {
            case 1:
                prevGameImg.sprite = Random;
                prevGameTitle.text = "Random";
                curGameImg.sprite = AnswerThePhone;
                curGameTitle.text = "Answer The Phone";
                nextGameImg.sprite = Cheers;
                nextGameTitle.text = "Cheers";
                break;
            case 2:
                prevGameImg.sprite = AnswerThePhone;
                prevGameTitle.text = "Answer The Phone";
                curGameImg.sprite = Cheers;
                curGameTitle.text = "Cheers";
                nextGameImg.sprite = CrackTheVault;
                nextGameTitle.text = "Crack The Vault";
                break;
            case 3:
                prevGameImg.sprite = Cheers;
                prevGameTitle.text = "Cheers";
                curGameImg.sprite = CrackTheVault;
                curGameTitle.text = "Crack The Vault";
                nextGameImg.sprite = DrinkContest;
                nextGameTitle.text = "Drink Contest";
                break;
            case 4:
                prevGameImg.sprite = CrackTheVault;
                prevGameTitle.text = "Crack The Vault";
                curGameImg.sprite = DrinkContest;
                curGameTitle.text = "Drink Contest";
                nextGameImg.sprite = FishingManiac;
                nextGameTitle.text = "Fishing Mania(c)";
                break;
            case 5:
                prevGameImg.sprite = DrinkContest;
                prevGameTitle.text = "Drink Contest";
                curGameImg.sprite = FishingManiac;
                curGameTitle.text = "Fishing Mania(c)";
                nextGameImg.sprite = GyropeWalker;
                nextGameTitle.text = "Gyrope Walker";
                break;
            case 6:
                prevGameImg.sprite = FishingManiac;
                prevGameTitle.text = "Fishing Mania(c)";
                curGameImg.sprite = GyropeWalker;
                curGameTitle.text = "Gyrope Walker";
                nextGameImg.sprite = HighStriker;
                nextGameTitle.text = "High Striker";
                break;
            case 7:
                prevGameImg.sprite = GyropeWalker;
                prevGameTitle.text = "Gyrope Walker";
                curGameImg.sprite = HighStriker;
                curGameTitle.text = "High Striker";
                nextGameImg.sprite = Paparazo;
                nextGameTitle.text = "Paparazo";
                break;
            case 8:
                prevGameImg.sprite = HighStriker;
                prevGameTitle.text = "High Striker";
                curGameImg.sprite = Paparazo;
                curGameTitle.text = "Paparazo";
                nextGameImg.sprite = QuickDraw;
                nextGameTitle.text = "Quick Draw Showdown";
                break;
            case 9:
                prevGameImg.sprite = Paparazo;
                prevGameTitle.text = "Paparazo";
                curGameImg.sprite = QuickDraw;
                curGameTitle.text = "Quick Draw Showdown";
                nextGameImg.sprite = SignalFlag;
                nextGameTitle.text = "Signal Flag";
                break;
            case 10:
                prevGameImg.sprite = QuickDraw;
                prevGameTitle.text = "Quick Draw Showdown";
                curGameImg.sprite = SignalFlag;
                curGameTitle.text = "Signal Flag";
                nextGameImg.sprite = Skeeroscope;
                nextGameTitle.text = "Skeeroscope";
                break;
            case 11:
                prevGameImg.sprite = SignalFlag;
                prevGameTitle.text = "Signal Flag";
                curGameImg.sprite = Skeeroscope;
                curGameTitle.text = "Skeeroscope";
                nextGameImg.sprite = Random;
                nextGameTitle.text = "Random";
                break;
            case 12:
                prevGameImg.sprite = Skeeroscope;
                prevGameTitle.text = "Skeeroscope";
                curGameImg.sprite = Random;
                curGameTitle.text = "Random";
                nextGameImg.sprite = AnswerThePhone;
                nextGameTitle.text = "Answer The Phone";
                break;
            default:
                break;
        }
    }

    public void SelectGame()
    {
        switch (curGameSelected)
        {
            case 1:
                SceneManager.LoadScene("AnswerThePhone");
                break;
            case 2:
                SceneManager.LoadScene("Cheers");
                break;
            case 3:
                SceneManager.LoadScene("CrackTheVault");
                break;
            case 4:
                SceneManager.LoadScene("DrinkContest");
                break;
            case 5:
                SceneManager.LoadScene("FishingManiac");
                break;
            case 6:
                SceneManager.LoadScene("GyropeWalker");
                break;
            case 7:
                SceneManager.LoadScene("HighStriker");
                break;
            case 8:
                SceneManager.LoadScene("Paparazo");
                break;
            case 9:
                SceneManager.LoadScene("QuickDraw");
                break;
            case 10:
                SceneManager.LoadScene("SignalFlag");
                break;
            case 11:
                SceneManager.LoadScene("Skeeroscope");
                break;
            case 12:
                randomGame();
                break;
            default:
                break;
        }
    }

    private void randomGame()
    {
        int levelRandomize = UnityEngine.Random.Range(1, 12);

        if (levelRandomize == 1)
        {
            SceneManager.LoadScene("AnswerThePhone");
        }
        else if (levelRandomize == 2)
        {
            SceneManager.LoadScene("Cheers");
        }
        else if (levelRandomize == 3)
        {
            SceneManager.LoadScene("CrackTheVault");
        }
        else if (levelRandomize == 4)
        {
            SceneManager.LoadScene("DrinkContest");
        }
        else if (levelRandomize == 5)
        {
            SceneManager.LoadScene("FishingManiac");
        }
        else if (levelRandomize == 6)
        {
            SceneManager.LoadScene("GyropeWalker");
        }
        else if (levelRandomize == 7)
        {
            SceneManager.LoadScene("HighStriker");
        }
        else if (levelRandomize == 8)
        {
            SceneManager.LoadScene("Paparazo");
        }
        else if (levelRandomize == 9)
        {
            SceneManager.LoadScene("QuickDraw");
        }
        else if (levelRandomize == 10)
        {
            SceneManager.LoadScene("SignalFlag");
        }
        else if (levelRandomize == 11)
        {
            SceneManager.LoadScene("Skeeroscope");
        }
    }

    public void BackToMM()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
