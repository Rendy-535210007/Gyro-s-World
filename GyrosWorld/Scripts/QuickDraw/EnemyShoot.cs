using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //public float cooldown = 1.5f;
    public GameObject gunLight;
    public AudioSource gunShot;
    public QuickDrawGameMode getIsStart;
    //public Transform raycastEnemy;
    public GameObject loseUI;
    public GameObject playerUI;
    public GameObject gameController;
    [HideInInspector]
    public bool isAlive = true;

    [HideInInspector]
    public float lastShoot = 0;

    //float XRot;
    //float YRot;

    bool doOnce = false;
    
    void Update()
    {
        if(getIsStart.isStart && !doOnce)
        {
            doOnce = true;
            StartCoroutine(WaitForEnemyAttack());
        }

        /*
        if(Time.time - lastShoot >= cooldown && getIsStart.isStart && isAlive)
        {
            XRot = Random.Range(-2.5f, 2.5f);
            YRot = Random.Range(-87.5f, -92.5f);
            raycastEnemy.localRotation = Quaternion.Euler(XRot, YRot, 0f);

            lastShoot = Time.time;
            gunLight.SetActive(true);
            StartCoroutine(LightOut());
            gunShot.Play();
            if (Physics.Raycast(raycastEnemy.localPosition, raycastEnemy.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 50f))
            {
                if (hitInfo.collider.tag == "Player")
                {
                    loseUI.SetActive(true);
                    isAlive = false;
                    playerUI.SetActive(false);
                    gameController.SetActive(false);
                    int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
                    PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), 0);
                }
            } 
        }
        */
    }

    IEnumerator WaitForEnemyAttack()
    {
        yield return new WaitForSeconds(3.5f);
        
        if(isAlive)
        {
            gunLight.SetActive(true);
            StartCoroutine(LightOut());
            gunShot.Play();
            loseUI.SetActive(true);
            isAlive = false;
            playerUI.SetActive(false);
            gameController.SetActive(false);
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), -1);
        }
    }

    IEnumerator LightOut()
    {
        yield return new WaitForSeconds(0.1f);
        gunLight.SetActive(false);
    }
}
