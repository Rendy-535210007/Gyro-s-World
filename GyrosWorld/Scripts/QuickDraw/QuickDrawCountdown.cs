using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuickDrawCountdown : MonoBehaviour
{
    public GameObject gameController;
    public GameObject playerUI;
    public QuickDrawGameMode getStartGame;
    public EnemyShoot getLastShoot;
    public GameObject enemyCowboy;
    public Animator enemyCowboyAnimator;
    public AudioSource audioSrc;
    public AudioClip readySFX;
    public AudioClip steadySFX;
    public AudioClip fireSFX;
    public TextMeshProUGUI countdownText;

    float randomTime;

    void Start()
    {
        StartCoroutine(WaitForReadySFX());
        randomTime = Random.Range(2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForReadySFX()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(WaitForSteadySFX());
        audioSrc.clip = readySFX;
        audioSrc.Play();
        countdownText.text = "Ready";
    }

    IEnumerator WaitForSteadySFX()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(StartTheGame());
        audioSrc.clip = steadySFX;
        audioSrc.Play();
        countdownText.text = "Steady";
    }

    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(randomTime + 1.5f);
        gameController.SetActive(true);
        playerUI.SetActive(true);
        audioSrc.clip = fireSFX;
        audioSrc.Play();
        getStartGame.isStart = true;
        enemyCowboy.transform.localRotation = Quaternion.Euler(0, -50, 0);
        enemyCowboyAnimator.SetTrigger("FireAnim");
        getLastShoot.lastShoot = Time.time + 1f;
        countdownText.text = "FIRE!";
        StartCoroutine(WaitForDestroyGameObj());
    }

    IEnumerator WaitForDestroyGameObj()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
