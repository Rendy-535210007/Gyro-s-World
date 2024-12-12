using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionHighStriker : MonoBehaviour
{
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;

    Gyroscope script_Gyro;
    AudioSource getAudioSource;
    bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        getAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(script_Gyro.rotationRateUnbiased.z) >= 7f && !doOnce)
        // if (Input.GetAxis("Mouse Y") >= 7.5f && !doOnce)
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
