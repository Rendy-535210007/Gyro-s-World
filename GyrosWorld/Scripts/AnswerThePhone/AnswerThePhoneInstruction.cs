using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerThePhoneInstruction : MonoBehaviour
{
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip instructionAudio;
    public AudioClip InstructionComplete;

    Gyroscope script_Gyro;
    AudioSource getAudioSource;
    float timeToCompleteInstruction = 2;
    bool isComplete = false;
    bool doOnce = false;

    private void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        getAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(script_Gyro.rotationRate.x >= -0.5f && script_Gyro.rotationRate.x <= 0.5f && script_Gyro.rotationRate.y >= -0.5f && script_Gyro.rotationRate.y <= 0.5f && script_Gyro.rotationRate.z >= -0.5f && script_Gyro.rotationRate.z <= 0.5f)
        {
            timeToCompleteInstruction -= Time.deltaTime;
        } else
        {
            timeToCompleteInstruction = 2;
        }

        if(timeToCompleteInstruction <= 0 && !isComplete)
        {
            isComplete = true;
            doOnce = true;
        }
        else if(timeToCompleteInstruction > 0 && isComplete)
        {
            isComplete = false;
            doOnce = true;
        }

        // hanya ubah ifnya saja ini
        if (isComplete && doOnce)
        {
            doOnce = false;
            StartButton.SetActive(true);
            getAudioSource.clip = InstructionComplete;
            getAudioSource.Play();
        }
        else if(!isComplete && doOnce)
        {
            doOnce = false;
            StartButton.SetActive(false);
            getAudioSource.clip = instructionAudio;
            getAudioSource.Play();
        }
    }

    public void StartTheGame()
    {
        countdownUI.SetActive(true);
        countdownAudio.Play();
        Destroy(gameObject);
    }
}
