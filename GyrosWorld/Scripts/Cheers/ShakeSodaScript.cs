using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeSodaScript : MonoBehaviour
{
    public GameObject cap;
    public float forceStrength = 500;
    public float decrementHealth = 1f;
    public AudioSource audioSrc;
    public AudioClip sodaShakeSFX, popSFX;
    public float cooldown = 0.5f;
    public GameObject sodaEffect;
    public GameObject showUI;
    public float minHealth = 50f;
    public float maxHealth = 100f;
    public ParticleSystem shakeEffect;

    float lastSFXPlay = -1;
    bool isPoped = false;
    Rigidbody capRb;
    Gyroscope script_Gyro;
    float sodaHealth;

    // Start is called before the first frame update
    void Start()
    {
        sodaHealth = Random.Range(minHealth, maxHealth);
        capRb = cap.GetComponent<Rigidbody>();

        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShakeScript();

        if (sodaHealth <= 0 && !isPoped)
        {
            isPoped = true;
            PopedSoda();
        }
    }

    private void PopedSoda()
    {
        capRb.AddForce(cap.transform.up * forceStrength);
        audioSrc.Stop();
        audioSrc.clip = popSFX;
        audioSrc.Play();
        sodaEffect.SetActive(true);
        StartCoroutine(ShowUI());
    }

    private void ShakeScript()
    {
        if ((script_Gyro.rotationRateUnbiased.x <= -10f || script_Gyro.rotationRateUnbiased.x >= 10f || script_Gyro.rotationRateUnbiased.z <= -10f || script_Gyro.rotationRateUnbiased.z >= 10f) && !isPoped)
        {
            sodaHealth -= decrementHealth;
            if (Time.time - lastSFXPlay >= cooldown)
            {
                lastSFXPlay = Time.time;
                audioSrc.clip = sodaShakeSFX;
                audioSrc.Play();
                shakeEffect.Play();
            }
        }
    }

    IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(2);
        showUI.SetActive(true);
    }
}
