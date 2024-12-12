using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public GameObject gameController;
    public Transform RaycastPoint;
    public Animator enemyAnimator;
    public GameObject gunLight;
    public AudioSource gunShot;
    public float cooldown = 1f;
    public QuickDrawGameMode getIsStart;
    public PlayerRotation getPlayerSens;
    public TextMeshPro sensText;
    public GameObject instructionStuff;
    public GameObject instructionUI;
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public EnemyShoot getEnemyAlive;
    public GameObject playerUI;
    public GameObject winUI;
    public Text playTimeText;
    public Sprite GreyBadge;
    public Sprite YellowBadge;
    public Image Star1;
    public Image Star2;
    public Image Star3;
    public QuickDrawGameMode getQDGameMode;
    public Text playerText;
    [HideInInspector] public float totalShot;

    float lastShot = -1f;

    public void Shooting()
    {
        if (Physics.Raycast(RaycastPoint.position, RaycastPoint.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 50f))
        {
            if(getIsStart.isStart)
            {
                if (Time.time - lastShot >= cooldown && totalShot < 1)
                {
                    totalShot++;
                    lastShot = Time.time;
                    gunShot.Play();
                    gunLight.SetActive(true);
                    StartCoroutine(LightOut());
                    if (hitInfo.collider.tag == "Enemy")
                    {
                        enemyAnimator.SetTrigger("DeathAnimTrigger");
                        playerUI.SetActive(false);
                        gameController.SetActive(false);
                        winUI.SetActive(true);
                        getEnemyAlive.isAlive = false;
                        playTimeText.text = getQDGameMode.playTime.ToString("F3");
                        int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
                        playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
                        PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), getQDGameMode.playTime);
                        if (getQDGameMode.playTime <= 1.5f)
                        {
                            Star1.sprite = YellowBadge;
                        } else
                        {
                            Star1.sprite = GreyBadge;
                        }
                        Star2.sprite = GreyBadge;
                        if(totalShot <= 1)
                        {
                            Star3.sprite = YellowBadge;
                        } else
                        {
                            Star3.sprite = GreyBadge;
                        }
                    }
                    else if(hitInfo.collider.tag == "HeadShot")
                    {
                        enemyAnimator.SetTrigger("DeathAnimTrigger");
                        winUI.SetActive(true);
                        getEnemyAlive.isAlive = false;
                        playTimeText.text = getQDGameMode.playTime.ToString("F3");
                        int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
                        playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
                        PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), getQDGameMode.playTime);
                        playerUI.SetActive(false);
                        gameController.SetActive(false);
                        if (getQDGameMode.playTime <= 1.5f)
                        {
                            Star1.sprite = YellowBadge;
                        }
                        else
                        {
                            Star1.sprite = GreyBadge;
                        }
                        Star2.sprite = YellowBadge;
                        if (totalShot <= 1)
                        {
                            Star3.sprite = YellowBadge;
                        }
                        else
                        {
                            Star3.sprite = GreyBadge;
                        }
                    }
                }
            } else
            {
                if (hitInfo.collider.tag == "IncreaseSens")
                {
                    getPlayerSens.gyroSens += 0.1f;
                    getPlayerSens.gyroSens = Mathf.Clamp(getPlayerSens.gyroSens, 0.1f, 10);
                    sensText.text = getPlayerSens.gyroSens.ToString("F1");
                }
                else if (hitInfo.collider.tag == "DecreaseSens")
                {
                    getPlayerSens.gyroSens -= 0.1f;
                    getPlayerSens.gyroSens = Mathf.Clamp(getPlayerSens.gyroSens, 0.1f, 10);
                    sensText.text = getPlayerSens.gyroSens.ToString("F1");
                }
                else if (hitInfo.collider.tag == "QuickDrawTarget")
                {

                    countdownUI.SetActive(true);
                    countdownAudio.Play();
                    gameController.SetActive(false);
                    Destroy(instructionStuff);
                    Destroy(instructionUI);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    IEnumerator LightOut()
    {
        yield return new WaitForSeconds(0.1f);
        gunLight.SetActive(false);
    }
}
