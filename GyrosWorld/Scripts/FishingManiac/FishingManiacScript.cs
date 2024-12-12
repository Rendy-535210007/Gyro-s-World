using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishingManiacScript : MonoBehaviour
{
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
    public GameObject timeplayTextGO;
    public GameObject pointTextGameObj;
    public GameObject endUI;
    public TextMeshProUGUI endTotalPointText;
    public TextMeshProUGUI playerText;

    TextMeshPro pointTMPro;
    TextMeshPro timeplayText;
    float lastTurn = 0;
    float playTime = 60f;
    float catchProgressFloat = 0;
    float point = 0;
    float distance;
    int step = 0;
    float waitTime;
    float pointMultiply = 1;
    float curStrengthYPos = 0;
    float fishYPos = 0;
    float timeCatchFish;
    float durationTillTheFishCaught;
    float fishBarSpeed;
    float curFishSpeed;
    float stringHoldTime = 0;
    float pointGet;
    float startFish;

    Gyroscope script_Gyro;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        timeplayTextGO.SetActive(true);
        timeplayText = timeplayTextGO.GetComponent<TextMeshPro>();
        pointTMPro = pointTextGameObj.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        playTime -= Time.deltaTime;
        timeplayText.text = playTime.ToString("F2");

        switch(step)
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
        
        if(playTime <= 0)
        {
            endUI.SetActive(true);
            endTotalPointText.text = point.ToString("F2");
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), point);
            fishingRodReelWindingSFX.Stop();
            Destroy(playerUI);
            Destroy(fishingBar);
            Destroy(pointTMPro);
            Destroy(timeplayText);
            Destroy(gameObject);
        }
    }

    void StartFishing()
    {
        if (script_Gyro.rotationRate.x >= 10)
        {
            waitTime = Random.Range(1.5f, 3f);
            step += 1;
            distance = script_Gyro.rotationRate.x;
            startString.SetActive(true);
            smallWaterSplashSFX.Play();
            stringEnd.position = new Vector3(6f + distance, 20f, 2f);
            startFish = Time.time;
            stringHoldTime = 0f;
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
            timeCatchFish = playTime;
        }
        else
        {
            waitTime -= Time.deltaTime;

            if ((script_Gyro.rotationRate.x > 1.5f || script_Gyro.rotationRate.x < -1.5f || script_Gyro.rotationRate.y > 1.5f || script_Gyro.rotationRate.y < -1.5f) && Time.time - startFish >= 0.5f)
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

        if(Time.time - lastTurn >= 1)
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
        curStrengthYPos = Mathf.Clamp(curStrengthYPos, -0.49f, 0.49f);
        curStrength.localPosition = new Vector3(-0.78f, curStrengthYPos, 0f);
        
        if(stringHoldTime >= 2)
        {
            warningText.SetActive(true);
        } else
        {
            warningText.SetActive(false);
        }

        if(getFishBar.isGetTheFish)
        {
            catchProgressFloat += Time.deltaTime;
        } else
        {
            catchProgressFloat -= Time.deltaTime;
        }

        if(catchProgressFloat >= durationTillTheFishCaught)
        {
            step += 1;
            catchProgressFloat = 0;
            pointMultiply = Mathf.Clamp(7 - ((timeCatchFish - playTime) - durationTillTheFishCaught), 1, 7);
            curStrengthYPos = 0;
            fishYPos = 0;
            fishProgressBar.position = new Vector3(0, 0, 0);
            curStrength.position = new Vector3(0, 0, 0);
            fishingRodReelWindingSFX.Stop();
            bigWaterSplashSFX.Play();
            theFish.SetActive(true);
            fishingBar.SetActive(false);
            playerUI.SetActive(false);
            pointTextGameObj.SetActive(true);
            pointGet = distance * pointMultiply;
            pointTMPro.text = pointGet.ToString("F2");
            point += pointGet;
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
        }
    }

    void GetTheFish()
    {
        stringEnd.position = theFish.transform.position;

        if(Input.touchCount >= 1)
        {
            step = 0;
            pointTextGameObj.SetActive(false);
            startString.SetActive(false);
            theFish.SetActive(false);
        }
    }
}
