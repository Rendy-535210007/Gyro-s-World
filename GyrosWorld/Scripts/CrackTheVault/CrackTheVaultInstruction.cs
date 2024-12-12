using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackTheVaultInstruction : MonoBehaviour
{
    public GameObject padlockUI;
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;
    public Transform vaultInputCode;
    public AudioSource safeCrackSFX;
    public AudioSource truePassSFX;
    public AudioSource unlockPadlockSFX;
    public GameObject instructionTitle;

    Gyroscope script_Gyro;
    AudioSource getAudioSource;
    int curZRot = 0;
    int VaultPass;
    float xRotation = 0;
    int xRotInt = 0;
    float timeToSuccess = 1.25f;
    bool isStart = false;

    private void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        getAudioSource = GetComponent<AudioSource>();

        VaultPass = Random.Range(-44, 45);
    }

    private void Update()
    {
        if(!isStart)
        {
            xRotation -= script_Gyro.rotationRateUnbiased.z * 2f;
            //xRotation -= script_Gyro.rotationRate.z * 2f;
        }
        if (xRotation > 183)
        {
            xRotation = -176;
        }
        else if (xRotation < -183)
        {
            xRotation = 176;
        }

        if ((int)xRotation % 4 == 0 && curZRot != (int)xRotation)
        {
            xRotInt = (int)xRotation;
            curZRot = xRotInt;
            if (xRotInt / 4 == VaultPass)
            {
                truePassSFX.Play();
            }
            else
            {
                safeCrackSFX.Play();
            }
        }

        if (xRotInt / 4 == VaultPass)
        {
            timeToSuccess -= Time.deltaTime;
        }
        else
        {
            timeToSuccess = 1.25f;
        }

        if (timeToSuccess <= 0)
        {
            unlockPadlockSFX.Play();
            VaultPass = 999;
            StartButton.SetActive(true);
            getAudioSource.clip = InstructionComplete;
            getAudioSource.Play();
        }

        vaultInputCode.localRotation = Quaternion.Euler(xRotInt, 0, 0);
    }

    public void StartTheGame()
    {
        countdownUI.SetActive(true);
        countdownAudio.Play();
        StartCoroutine(waitForPadlockUIShow());
        StartButton.SetActive(false);
        instructionTitle.SetActive(false);
        isStart = true;
    }

    IEnumerator waitForPadlockUIShow()
    {
        yield return new WaitForSeconds(4f);
        padlockUI.SetActive(true);
        Destroy(gameObject);
    }
}
