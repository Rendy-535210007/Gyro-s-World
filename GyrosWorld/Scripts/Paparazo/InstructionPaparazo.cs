using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPaparazo : MonoBehaviour
{
    public Transform raycastPoint;
    public GameObject countdownUI;
    public AudioSource countdownAudio;
    public GameObject StartButton;
    public AudioClip InstructionComplete;
    public AudioSource takeAPicSFX;
    public Image whiteBGImg;
    public Camera mainCam;
    public float zoomModifierSpeed = 0.5f;
    public float takeAPictureCooldown = 3f;
    public GameObject jamaicaPic;

    Vector2 firstTouchPrevPos, secondTouchPrevPos;
    float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
    float raycastLength = 20;
    float raycastLengthModifier = 1.25f;
    float lastShoot = -3;
    float alphaColor = 0;
    AudioSource getAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        getAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (alphaColor > 0)
        {
            alphaColor -= Time.deltaTime;
            whiteBGImg.color = new Color(255, 255, 255, alphaColor);
        }

        mainCam.fieldOfView = Mathf.Clamp(mainCam.fieldOfView, 1f, 100f);
        raycastLength = (120 - mainCam.fieldOfView) * raycastLengthModifier;
    }

    public void TakeAPicture()
    {
        if (Time.time - lastShoot >= takeAPictureCooldown)
        {
            lastShoot = Time.time;
            takeAPicSFX.Play();
            alphaColor = 1;
            if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out RaycastHit hitInfo, raycastLength))
            {
                if (hitInfo.collider.tag == "Enemy")
                {
                    jamaicaPic.SetActive(false);
                    StartButton.SetActive(true);
                    getAudioSource.clip = InstructionComplete;
                    getAudioSource.Play();
                }
            }
        }
    }

    public void StartTheGame()
    {
        countdownUI.SetActive(true);
        countdownAudio.Play();
        Destroy(gameObject);
    }
}
