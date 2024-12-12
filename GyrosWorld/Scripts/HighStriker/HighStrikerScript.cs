using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighStrikerScript : MonoBehaviour
{
    public GameObject meterCube;

    float forceStrength;
    Rigidbody meterCubeRB;
    Gyroscope script_Gyro;
    float hitTime;
    bool isLaunchHammer = false;
    float delay = 0.2f;
    public AudioSource hitSFX;
    public Transform mainCam;
    bool doOnce = false;
    float score = 0;

    public GameObject endUI;
    public Text playerText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        meterCubeRB = meterCube.GetComponent<Rigidbody>();
        isLaunchHammer = false;
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(script_Gyro.rotationRateUnbiased.z) >= 6f && !doOnce)
        {
            hitTime = Time.time + delay;
            isLaunchHammer = true;
            doOnce = true;
        }

        if(isLaunchHammer)
        {
            if(Time.time >= hitTime)
            {
                score = forceStrength;
                meterCubeRB.AddForce(meterCube.transform.up * (forceStrength * 15));
                isLaunchHammer = false;
                if(forceStrength > 0)
                {
                    hitSFX.Play();
                }
                StartCoroutine(WaitForShowEndUI());
            }
            else
            {
                mainCam.position = Vector3.Lerp(mainCam.position, new Vector3(-6.95f, 6.06f, 0.495f), 0.2f);
                forceStrength += Mathf.Abs(script_Gyro.rotationRateUnbiased.z);
                //forceStrength += Input.GetAxis("Mouse Y");
                //Debug.Log(forceStrength);
            }
        } else
        {
            forceStrength = 0;
        }
    }

    IEnumerator WaitForShowEndUI()
    {
        yield return new WaitForSeconds(2f);
        endUI.SetActive(true);
        int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
        playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
        PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), score);
        scoreText.text = Mathf.Round(score).ToString("F0");
    }
}
