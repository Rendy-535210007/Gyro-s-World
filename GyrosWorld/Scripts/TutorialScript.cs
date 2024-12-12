using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject InstructionUI;
    public AudioSource InstructionAudio;
    public GameObject InstruksiBIndo;
    public GameObject InstructionEnglish;
    public bool isTimeScore;

    public void SkipTutorial()
    {
        InstructionUI.SetActive(true);
        InstructionAudio.Play();
        Destroy(gameObject);
    }

    public void Start()
    {
        if(isTimeScore)
        {
            PlayerPrefs.SetInt("ScoreAsc", 0);
        } else
        {
            PlayerPrefs.SetInt("ScoreAsc", 1);
        }

        if (PlayerPrefs.GetInt("Language") == 0)
        {
            InstructionEnglish.SetActive(true);
            InstruksiBIndo.SetActive(false);
        }
        else
        {
            InstructionEnglish.SetActive(false);
            InstruksiBIndo.SetActive(true);
        }
    }
}
