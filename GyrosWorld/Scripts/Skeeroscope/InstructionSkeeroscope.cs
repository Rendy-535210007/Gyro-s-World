using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSkeeroscope : MonoBehaviour
{
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;
    public GameObject ballPrefab;
    public Transform spawnLoc;

    AudioSource getAudioSource;
    Gyroscope script_Gyro;
    float throwPower;
    bool doOnce = false;
    GameObject curball;

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
        //throwPower = Input.GetAxis("Mouse Y");

        //if (Input.GetAxis("Mouse Y") >= 6.5f && !doOnce)
        if (script_Gyro.rotationRateUnbiased.x <= -6.5f && !doOnce)
        {
            throwPower = Mathf.Abs(script_Gyro.rotationRateUnbiased.x);
            doOnce = true;
            ThrowABall();
            StartButton.SetActive(true);
            getAudioSource.clip = InstructionComplete;
            getAudioSource.Play();
        }
    }

    public void StartTheGame()
    {
        countdownUI.SetActive(true);
        countdownAudio.Play();
        Destroy(curball);
        Destroy(gameObject);
    }

    private void ThrowABall()
    {
        curball = Instantiate(ballPrefab, spawnLoc.position, Quaternion.identity);
        curball.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower * 125);
    }
}
