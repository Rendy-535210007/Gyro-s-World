using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThrowBallScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnLoc;
    public bool canThrow;
    public float totalPoint;
    public TextMeshProUGUI totalPointText;
    public int totalBall;
    public int ballIn;
    public TextMeshProUGUI totalBallText;

    private float throwPower;
    Gyroscope script_Gyro;

    float lastThrow;

    private void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
        totalBall = 3;
        totalBallText.text = "x" + totalBall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //throwPower = Input.GetAxis("Mouse Y");

        //if (throwPower >= 6.5f && canThrow && totalBall > 0)
        if (script_Gyro.rotationRateUnbiased.x <= -6.5f && canThrow && totalBall > 0)
        {
            throwPower = Mathf.Abs(script_Gyro.rotationRateUnbiased.x);
            ThrowBall();
        }
        
        if(Time.time - lastThrow >= 2)
        {
            canThrow = true;
        }

        totalPointText.text = totalPoint.ToString("F0");
    }

    void ThrowBall()
    {
        totalBall--;
        totalBallText.text = "x" + totalBall.ToString();
        canThrow = false;
        GameObject curball = Instantiate(ballPrefab, spawnLoc.position, Quaternion.identity);
        curball.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower * 125);
        
        lastThrow = Time.time;
    }

    private void OnEnable()
    {
        canThrow = true;
        totalPoint = 0;
        ballIn = 0;
    }
}
