using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheersInstruction : MonoBehaviour
{
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;

    Gyroscope script_Gyro;
    AudioSource getAudioSource;
    bool doOnce = false;

    private void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        getAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // hanya ubah ifnya saja ini
        if ((script_Gyro.rotationRateUnbiased.x <= -10f || script_Gyro.rotationRateUnbiased.x >= 10f || script_Gyro.rotationRateUnbiased.z <= -10f || script_Gyro.rotationRateUnbiased.z >= 10f) && !doOnce)
        {
            doOnce = true;
            StartButton.SetActive(true);
            getAudioSource.clip = InstructionComplete;
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
