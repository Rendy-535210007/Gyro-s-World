using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCodeScript : MonoBehaviour
{
    public Transform vaultInputCode;
    public AudioSource safeCrackSFX;
    public AudioSource truePassSFX;
    public AudioSource unlockPadlockSFX;
    public Text playTimeText;
    public Text totalPlayTimeEndUI;
    public Text playerText;
    public GameObject padlockUI;
    public GameObject endUI;
    public Sprite unlockedPadlock;
    public Image padlock1;
    public Image padlock2;
    public Image padlock3;

    Gyroscope script_Gyro;
    int successTimes = 0;
    int tempCode;
    int curZRot = 0;
    int VaultPass;
    float xRotation = 0;
    int xRotInt = 0;
    float timeToSuccess = 1.25f;
    float playTime;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        VaultPass = Random.Range(-44, 45);
    }

    // Update is called once per frame
    void Update()
    {
        xRotation -= script_Gyro.rotationRateUnbiased.z * 2f;
        if(xRotation > 183)
        {
            xRotation = -176;
        }
        else if(xRotation < -183)
        {
            xRotation = 176;
        }
        
        if((int)xRotation % 4 == 0 && curZRot != (int)xRotation)
        {
            xRotInt = (int)xRotation;
            curZRot = xRotInt;
            if(xRotInt / 4 == VaultPass)
            {
                truePassSFX.Play();
            } else
            {
                safeCrackSFX.Play();
            }
        }

        if(xRotInt/4 == VaultPass)
        {
            timeToSuccess -= Time.deltaTime;
        } else
        {
            timeToSuccess = 1.25f;
        }

        if(timeToSuccess <= 0)
        {
            tempCode = VaultPass;
            unlockPadlockSFX.Play();
            successTimes++;

            ChangePadlockImageUI();

            while(VaultPass == tempCode)
            {
                VaultPass = Random.Range(-44, 45);
            }
        }

        if(successTimes >= 3)
        {
            padlockUI.SetActive(false);
            endUI.SetActive(true);
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            totalPlayTimeEndUI.text = playTime.ToString("F3");
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), playTime);
            Destroy(gameObject);
        }

        vaultInputCode.localRotation = Quaternion.Euler(xRotInt, 0, 0);

        playTime += Time.deltaTime;

        playTimeText.text = playTime.ToString("F3");
    }

    private void ChangePadlockImageUI()
    {
        if(successTimes == 1)
        {
            padlock1.sprite = unlockedPadlock;
        } else if(successTimes == 2)
        {
            padlock2.sprite = unlockedPadlock;
        } else if(successTimes >= 3)
        {
            padlock3.sprite = unlockedPadlock;
        }
    }
}
