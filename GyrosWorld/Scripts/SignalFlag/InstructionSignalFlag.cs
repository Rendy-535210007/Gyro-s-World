using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionSignalFlag : MonoBehaviour
{
    public FlagScript getFlagPos;
    public TextMeshProUGUI commandText;
    public Image commandImg;
    public Transform theFlag;
    public GameObject playerUI;
    public AudioClip maleRight;
    public AudioClip maleDown;
    public AudioClip femaleRight;
    public AudioClip femaleDown;
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;
    public TextMeshProUGUI instructionText;

    Gyroscope script_Gyro;
    AudioSource audioSrc;
    int step;
    bool doOnce = false;
    // Instruction Step:
    // 1. male right
    // 2. male down
    // 3. female right
    // 4. female down


    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
        playerUI.SetActive(true);
        audioSrc = GetComponent<AudioSource>();
        step = 1;
    }

    void Update()
    {
        //theFlag.rotation = script_Gyro.attitude;
        theFlag.Rotate(0, 0, script_Gyro.rotationRateUnbiased.z * 2);
        //theFlag.Rotate(0, 0, -Input.GetAxis("Mouse X") * 100 * Time.deltaTime);

        switch(step)
        {
            case 1:
                Step1();
                break;
            case 2:
                Step2();
                break;
            case 3:
                Step3();
                break;
            case 4:
                Step4();
                break;
            default:
                if(!doOnce)
                {
                    doOnce = true;
                    StartButton.SetActive(true);
                    audioSrc.clip = InstructionComplete;
                    audioSrc.Play();
                    playerUI.SetActive(false);
                }
                break;
        }
    }

    void Step1()
    {
        if (!doOnce)
        {
            doOnce = true;
            commandText.text = "RIGHT";
            commandImg.color = Color.yellow;
            audioSrc.clip = maleRight;
            audioSrc.Play();
            instructionText.text = "Man: Turn your cell phone according to the instructions";
        }

        if(getFlagPos.flagPos == 3)
        {
            step++;
            doOnce = false;
            audioSrc.Stop();
        }
    }

    void Step2()
    {
        if (!doOnce)
        {
            doOnce = true;
            commandText.text = "DOWN";
            commandImg.color = Color.yellow;
            audioSrc.clip = maleDown;
            audioSrc.Play();
            instructionText.text = "Man: Turn your cell phone according to the instructions";
        }

        if (getFlagPos.flagPos == 4)
        {
            step++;
            doOnce = false;
            audioSrc.Stop();
        }
    }

    void Step3()
    {
        if (!doOnce)
        {
            doOnce = true;
            commandText.text = "RIGHT";
            commandImg.color = Color.red;
            audioSrc.clip = femaleRight;
            audioSrc.Play();
            instructionText.text = "Woman: Turn your cell phone in the opposite direction to the instruction";
        }

        if (getFlagPos.flagPos == 2)
        {
            step++;
            doOnce = false;
            audioSrc.Stop();
        }
    }

    void Step4()
    {
        if (!doOnce)
        {
            doOnce = true;
            commandText.text = "DOWN";
            commandImg.color = Color.red;
            audioSrc.clip = femaleDown;
            audioSrc.Play();
            instructionText.text = "Woman: Turn your cell phone in the opposite direction to the instruction";
        }

        if (getFlagPos.flagPos == 1)
        {
            step++;
            doOnce = false;
            audioSrc.Stop();
        }
    }

    public void StartTheGame()
    {
        theFlag.eulerAngles = new Vector3(0,0,0);
        countdownUI.SetActive(true);
        countdownAudio.Play();
        Destroy(gameObject);
    }
}
