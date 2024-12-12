using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPointScript : MonoBehaviour
{
    public float pointValue = 0;
    public ParticleSystem starEffect;
    public ThrowBallScript getThrowBallScript;
    public AudioSource audioSFX;
    public GameObject endUI;
    public Text endUIPoint;
    public Text playerText;
    public GameObject playerUI;
    public GameObject gameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(pointValue > 0)
            {
                audioSFX.Play();
            }
            getThrowBallScript.totalPoint += pointValue;
            Destroy(other.gameObject);
            starEffect.Play();
            getThrowBallScript.ballIn++;

            if(getThrowBallScript.ballIn >= 3)
            {
                StartCoroutine(WaitForEndUIShowUp());
            }
        }
    }

    IEnumerator WaitForEndUIShowUp()
    {
        yield return new WaitForSeconds(0.7f);
        endUI.SetActive(true);
        endUIPoint.text = getThrowBallScript.totalPoint.ToString("F0");
        int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
        playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
        PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), getThrowBallScript.totalPoint);
        Destroy(gameController);
        playerUI.SetActive(false);
    }
}
