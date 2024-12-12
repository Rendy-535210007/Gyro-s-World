using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsThePhoneScript : MonoBehaviour
{
    public GameObject RingingUI;
    public Text respTimeText;
    public Text playerText;
    public GameObject winUI;
    public GameObject loseUI;
    public AudioSource pickedUpPhoneSFX;
    public AudioClip ringingAudio;

    AudioSource GetAudioSource;
    float timeDurationBeforeRing;
    bool isRinging = false;
    Gyroscope script_Gyro;
    float ringTime;
    float responseTime;

    // Start is called before the first frame update
    void Start()
    {
        timeDurationBeforeRing = Random.Range(4f, 7f);

        GetAudioSource = GetComponent<AudioSource>();
        GetAudioSource.Play();

        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        StartCoroutine(WaitForRinging());
    }

    // Update is called once per frame
    void Update()
    {
        if (script_Gyro.rotationRate.x <= -0.5f || script_Gyro.rotationRate.x >= 0.5f || script_Gyro.rotationRate.y <= -0.5f || script_Gyro.rotationRate.y >= 0.5f || script_Gyro.rotationRate.z <= -0.5f || script_Gyro.rotationRate.z >= 0.5f || Input.GetKeyDown(KeyCode.Space))
        {
            if(isRinging)
            {
                winUI.SetActive(true);
                responseTime = Time.time - ringTime;
                int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
                playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
                respTimeText.text = responseTime.ToString("F3");
                PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), responseTime);
                pickedUpPhoneSFX.Play();
                Destroy(gameObject);
            } else
            {
                int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
                PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), -1);
                loseUI.SetActive(true);
                pickedUpPhoneSFX.Play();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator WaitForRinging()
    {
        yield return new WaitForSeconds(timeDurationBeforeRing);
        isRinging = true;
        RingingUI.SetActive(true);
        GetAudioSource.clip = ringingAudio;
        GetAudioSource.Play();
        ringTime = Time.time;
    }
}
