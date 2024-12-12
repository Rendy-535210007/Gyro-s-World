using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateCupScript : MonoBehaviour
{
    public GameObject drinkFromLeft;
    public GameObject drinkFromRight;
    public TextMeshProUGUI playTimeText;
    public Transform cup;
    public GameObject timeUI;
    public GameObject EndUI;
    public AudioSource EndSFX;
    public Text totalWaterText;
    public int totalWater = 0;
    public GameObject liquidPrefab;
    public Text playerText;

    Gyroscope script_Gyro;
    GameObject spawnedLiquid;
    bool isLeft = false;
    float zRotation = 0;
    float timePlay = 30;
    bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        timeUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        zRotation += script_Gyro.rotationRateUnbiased.z * 3;
        //zRotation += Input.GetAxis("Mouse X");
        if (zRotation >= 180)
        {
            zRotation = -179.99f;
        }
        else if (zRotation <= -180)
        {
            zRotation = 179.99f;
        }

        if (zRotation >= -17 && zRotation <= 17 && canSpawn)
        {
            canSpawn = false;
            if (spawnedLiquid != null)
            {
                Destroy(spawnedLiquid);
            }
            Instantiate(liquidPrefab, cup.position, cup.localRotation);

        }
        else if ((zRotation <= 20 || zRotation >= 20) && !canSpawn)
        {
            canSpawn = true;
            spawnedLiquid = GameObject.FindGameObjectWithTag("Liquids");
        }

        if (isLeft && zRotation < 0 && zRotation >= -10)
        {
            isLeft = false;
            drinkFromRight.SetActive(true);
            drinkFromLeft.SetActive(false);
        }
        else if (!isLeft && zRotation > 0 && zRotation <= 10)
        {
            isLeft = true;
            drinkFromLeft.SetActive(true);
            drinkFromRight.SetActive(false);
        }

        cup.localRotation = Quaternion.Euler(0, 0, zRotation);

        timePlay -= Time.deltaTime;

        if (timePlay <= 0)
        {
            timeUI.SetActive(false);
            EndUI.SetActive(true);
            Destroy(drinkFromLeft);
            Destroy(drinkFromRight);
            totalWaterText.text = totalWater.ToString();
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), totalWater);
            EndSFX.Play();
            Destroy(gameObject);
        }

        playTimeText.text = timePlay.ToString("F2");
    }
}
