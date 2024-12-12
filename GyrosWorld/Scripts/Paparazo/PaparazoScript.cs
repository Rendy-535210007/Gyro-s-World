using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaparazoScript : MonoBehaviour
{
    public GameObject idol;
    public GameObject PlayerUI;
    public Transform raycastPoint;
    public Camera mainCam;
    public float zoomModifierSpeed = 1f;
    public float takeAPictureCooldown = 3f;
    public AudioSource takeAPicSFX;
    public Image whiteBGImg;
    public GameObject geishaChecklist;
    public GameObject rugbyChecklist;
    public GameObject EODChecklist;
    public GameObject Achievement1;
    public GameObject Achievement2;
    public GameObject Achievement3;
    public GameObject endUI;
    public Text geishaTimeText;
    public Text rugbyTimeText;
    public Text EODTimeText;
    public Text totalPlayTimeText;
    public Text playerText;
    public Text timeDurationText;

    float score;
    float geishaTime;
    float rugbyTime;
    float EODTime;
    float timePlay = 0;
    bool geisha = false;
    bool rugby = false;
    bool EOD = false;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;
    float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
    float raycastLength = 20;
    float raycastLengthModifier = 1.25f;
    float lastShoot = -3;
    float alphaColor = 0;
    bool boolAchievement1 = false;
    int totalShoot = 0;
    bool isFirstShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.fieldOfView = 100;
        PlayerUI.SetActive(true);
        idol.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timePlay += Time.deltaTime;
        timeDurationText.text = (90f - timePlay).ToString("F2");

        if(timePlay >= 90)
        {
            if (totalShoot <= 2)
            {
                score += 100;
            }
            endUI.SetActive(true);
            Destroy(PlayerUI);
            geishaTimeText.text = geishaTime.ToString("F3");
            rugbyTimeText.text = rugbyTime.ToString("F3");
            EODTimeText.text = EODTime.ToString("F3");
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            Achievement1.SetActive(boolAchievement1);
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), score);
            totalPlayTimeText.text = score.ToString();
            Destroy(gameObject);
        }

        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
            touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

            zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;
            
            if (touchesPrevPosDifference > touchesCurPosDifference)
            {
                mainCam.fieldOfView += zoomModifier;
            }
            if (touchesPrevPosDifference < touchesCurPosDifference)
            {
                mainCam.fieldOfView -= zoomModifier;
            }
        }

        if(alphaColor > 0)
        {
            alphaColor -= Time.deltaTime;
            whiteBGImg.color = new Color(255, 255, 255, alphaColor);
        }

        mainCam.fieldOfView = Mathf.Clamp(mainCam.fieldOfView, 1f, 100f);
        raycastLength = (120 - mainCam.fieldOfView) * raycastLengthModifier;
    }

    public void TakeAPicture()
    {
        if(Time.time - lastShoot >= takeAPictureCooldown)
        {
            lastShoot = Time.time;
            takeAPicSFX.Play();
            alphaColor = 1;
            totalShoot++;
            if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out RaycastHit hitInfo, raycastLength))
            {
                if (hitInfo.collider.tag == "Geisha")
                {
                    score += (300 + ((90f - timePlay) * 10));
                    geishaChecklist.SetActive(true);
                    geisha = true;
                    geishaTime = timePlay;
                    if(isFirstShoot && timePlay <= 10)
                    {
                        score += 500;
                        isFirstShoot = false;
                        boolAchievement1 = true;
                    }
                }
                else if (hitInfo.collider.tag == "Rugby")
                {
                    score += (400 + ((90f - timePlay) * 10));
                    rugbyChecklist.SetActive(true);
                    rugby = true;
                    rugbyTime = timePlay;
                    if (isFirstShoot && timePlay <= 10)
                    {
                        score += 500;
                        isFirstShoot = false;
                        boolAchievement1 = true;
                    }
                }
                else if (hitInfo.collider.tag == "EOD")
                {
                    score += (500 + ((90f - timePlay) * 10));
                    EODChecklist.SetActive(true);
                    EOD = true;
                    EODTime = timePlay;
                    if (isFirstShoot && timePlay <= 10)
                    {
                        score += 500;
                        isFirstShoot = false;
                        boolAchievement1 = true;
                    }
                }
            }
        }
        
        if(geisha && rugby && EOD)
        {
            endUI.SetActive(true);
            Destroy(PlayerUI);
            geishaTimeText.text = geishaTime.ToString("F3");
            rugbyTimeText.text = rugbyTime.ToString("F3");
            EODTimeText.text = EODTime.ToString("F3");
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            Achievement1.SetActive(boolAchievement1);
            if (timePlay <= 60)
            {
                Achievement2.SetActive(true);
                score += 1000;
            }
            if (totalShoot <= 3)
            {
                Achievement3.SetActive(true);
                score += 300;
            }
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), score);
            totalPlayTimeText.text = score.ToString();
            Destroy(gameObject);
        }
    }
}
