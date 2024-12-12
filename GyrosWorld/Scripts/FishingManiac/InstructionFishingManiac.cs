using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionFishingManiac : MonoBehaviour
{
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;
    public Transform curStrength;
    public Transform fishProgressBar;
    public Slider stringHealth;
    public Slider progressBar;
    public GameObject fishingBar;
    public GameObject playerUI;
    public GameObject theFish;
    public GameObject startString;
    public Transform stringEnd;
    public AudioSource fishingRodReelWindingSFX;
    public AudioSource bigWaterSplashSFX;
    public AudioSource smallWaterSplashSFX;
    public FishingBar getFishBar;
    public GameObject warningText;
    public GameObject instruction1;
    public GameObject instruction2;
    public GameObject instruction3;
    public AudioClip instruction1SFX;
    public AudioClip instruction3SFX;

    float startFish = 0;
    AudioSource getAudioSource;
    float lastTurn = 0;
    float waitTime;
    float distance;
    float catchProgressFloat = 0;
    int step = 0;
    float curStrengthYPos = 0;
    float fishYPos = 0;
    float durationTillTheFishCaught;
    float fishBarSpeed;
    float curFishSpeed;
    float stringHoldTime = 0;

    Gyroscope script_Gyro;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        getAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        switch (step)
        {
            case 0:
                StartFishing();
                break;
            case 1:
                WaitForTheFish();
                break;
            case 2:
                CatchingTheFish();
                break;
            case 3:
                GetTheFish();
                break;
            default:
                break;
        }
    }

    void StartFishing()
    {
        if (script_Gyro.rotationRate.x >= 10)
        {
            waitTime = Random.Range(2f, 4f);
            step += 1;
            distance = script_Gyro.rotationRate.x;
            startString.SetActive(true);
            smallWaterSplashSFX.Play();
            stringEnd.position = new Vector3(6f + distance, 20f, 2f);
            instruction1.SetActive(false);
            instruction2.SetActive(true);
            instruction3.SetActive(false);
            getAudioSource.Stop();
            startFish = Time.time;
        }
    }

    void WaitForTheFish()
    {
        if (waitTime <= 0)
        {
            step += 1;
            fishingBar.SetActive(true);
            playerUI.SetActive(true);
            fishingRodReelWindingSFX.Play();
            durationTillTheFishCaught = Mathf.Clamp(distance / 2.5f, 4, 7f);
            progressBar.maxValue = durationTillTheFishCaught;
            instruction1.SetActive(false);
            instruction2.SetActive(false);
            instruction3.SetActive(true);
            getAudioSource.clip = instruction3SFX;
            getAudioSource.Play();
        } else
        {
            waitTime -= Time.deltaTime;

            if ((script_Gyro.rotationRate.x > 2f || script_Gyro.rotationRate.x < -2f || script_Gyro.rotationRate.y > 2f || script_Gyro.rotationRate.y < -2f) && Time.time - startFish >= 0.5f)
            {
                waitTime += 0.65f;
                startFish = Time.time;
            }
        }
    }

    void CatchingTheFish()
    {
        progressBar.value = catchProgressFloat;
        stringHealth.value = stringHoldTime;

        if (Time.time - lastTurn >= 1)
        {
            lastTurn = Time.time;
            fishBarSpeed = Random.Range(-0.0125f, 0.0125f);
        }

        if (fishYPos <= -0.4f || fishYPos >= 0.4f)
        {
            fishBarSpeed *= -1;
        }

        if (Input.touchCount >= 1)
        {
            stringHoldTime += Time.deltaTime;
            curFishSpeed = fishBarSpeed / 3;
        }
        else
        {
            curFishSpeed = fishBarSpeed;
            stringHoldTime -= Time.deltaTime;
            stringHoldTime = Mathf.Clamp(stringHoldTime, 0, 3);
        }

        fishYPos += curFishSpeed;
        fishProgressBar.localPosition = new Vector3(-0.78f, fishYPos, 0f);

        curStrengthYPos -= script_Gyro.rotationRateUnbiased.x * Time.deltaTime * 1f;
        //curStrengthYPos += Input.GetAxis("Mouse Y") * 20 * Time.deltaTime;
        curStrengthYPos = Mathf.Clamp(curStrengthYPos, -0.49f, 0.49f);
        curStrength.localPosition = new Vector3(-0.78f, curStrengthYPos, 0f);

        if (stringHoldTime >= 2)
        {
            warningText.SetActive(true);
        }
        else
        {
            warningText.SetActive(false);
        }

        if (getFishBar.isGetTheFish)
        {
            catchProgressFloat += Time.deltaTime;
        }
        else
        {
            catchProgressFloat -= Time.deltaTime;
        }

        if (catchProgressFloat >= durationTillTheFishCaught)
        {
            step += 1;
            catchProgressFloat = 0;
            curStrengthYPos = 0;
            fishYPos = 0;
            fishProgressBar.position = new Vector3(0, 0, 0);
            curStrength.position = new Vector3(0, 0, 0);
            fishingRodReelWindingSFX.Stop();
            bigWaterSplashSFX.Play();
            theFish.SetActive(true);
            fishingBar.SetActive(false);
            playerUI.SetActive(false);
            // Instruction Complete
            StartButton.SetActive(true);
            getAudioSource.clip = InstructionComplete;
            getAudioSource.Play();
            stringHoldTime = 0f;
        }
        else if (catchProgressFloat <= -2.25f || stringHoldTime >= 3f)
        {
            step = 0;
            catchProgressFloat = 0;
            fishProgressBar.position = new Vector3(0, 0, 0);
            curStrength.position = new Vector3(0, 0, 0);
            fishingRodReelWindingSFX.Stop();
            fishingBar.SetActive(false);
            playerUI.SetActive(false);
            startString.SetActive(false);
            theFish.SetActive(false);
            instruction1.SetActive(true);
            instruction2.SetActive(false);
            instruction3.SetActive(false);
            getAudioSource.clip = instruction1SFX;
            getAudioSource.Play();
            stringHoldTime = 0f;
        }
    }

    void GetTheFish()
    {
        stringEnd.position = theFish.transform.position;
    }

    public void StartTheGame()
    {
        countdownUI.SetActive(true);
        countdownAudio.Play();
        startString.SetActive(false);
        theFish.SetActive(false);
        Destroy(gameObject);
    }
}
