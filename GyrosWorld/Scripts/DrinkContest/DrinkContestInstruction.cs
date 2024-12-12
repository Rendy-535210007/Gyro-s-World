using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkContestInstruction : MonoBehaviour
{
    public GameObject InstructiondrinkFromLeft;
    public GameObject InstructiondrinkFromRight;
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionAudio;
    public AudioClip InstructionComplete;
    public Transform cup;
    public int totalWater = 0;
    public GameObject drinkFromRight;
    public GameObject liquidPrefab;

    GameObject spawnedLiquid;
    Gyroscope script_Gyro;
    AudioSource getAudioSource;
    bool doOnce = false;
    bool isLeft = false;
    float zRotation = 0;
    bool canSpawn = false;

    private void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        getAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        zRotation += script_Gyro.rotationRateUnbiased.z * 3;
        if (zRotation >= 180)
        {
            zRotation = -179.99f;
        }
        else if (zRotation <= -180)
        {
            zRotation = 179.99f;
        }

        if (zRotation >= -5 && zRotation <= 5 && canSpawn)
        {
            canSpawn = false;
            Destroy(spawnedLiquid);
            Instantiate(liquidPrefab, cup.position, cup.localRotation);

        } else if((zRotation <= -10 || zRotation >= 10) && !canSpawn)
        {
            canSpawn = true;
            spawnedLiquid = GameObject.FindGameObjectWithTag("Liquids");
        }

        if (isLeft && zRotation < 0 && zRotation >= -10)
        {
            isLeft = false;
            InstructiondrinkFromRight.SetActive(true);
            InstructiondrinkFromLeft.SetActive(false);
        }
        else if (!isLeft && zRotation > 0 && zRotation <= 10)
        {
            isLeft = true;
            InstructiondrinkFromLeft.SetActive(true);
            InstructiondrinkFromRight.SetActive(false);
        }

        cup.localRotation = Quaternion.Euler(0, 0, zRotation);

        // hanya ubah ifnya saja ini
        if (totalWater >= 100 && !doOnce)
        {
            doOnce = true;
            StartButton.SetActive(true);
            getAudioSource.clip = InstructionComplete;
            getAudioSource.Play();
        } else if(totalWater < 100 && doOnce)
        {
            doOnce = false;
            StartButton.SetActive(false);
            getAudioSource.clip = InstructionAudio;
            getAudioSource.Play();
        }
    }

    public void StartTheGame()
    {
        cup.localRotation = Quaternion.Euler(0, 0, 0);
        spawnedLiquid = GameObject.FindGameObjectWithTag("Liquids");
        Destroy(spawnedLiquid);
        Instantiate(liquidPrefab, cup.position, cup.localRotation);
        drinkFromRight.SetActive(true);
        Destroy(InstructiondrinkFromLeft);
        Destroy(InstructiondrinkFromRight);
        countdownUI.SetActive(true);
        countdownAudio.Play();
        Destroy(gameObject);
    }
}
