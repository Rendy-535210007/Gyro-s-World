using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyropeWalkerScript : MonoBehaviour
{
    public bool isGameStart;
    public Transform thePlayer;
    public float speed = 1;
    public Transform playerSpawn;
    public float playTime;
    public float gyroSens = 2;
    
    Gyroscope script_Gyro;
    private float zRot = 0;
    private float zRotMultiply = 1;
    private float unbalanceRot = 1;

    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;

        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;

        //zRot -= Input.GetAxis("Mouse X");
        zRot += script_Gyro.rotationRateUnbiased.z * gyroSens;

        if (Input.touchCount > 0)
        {
            thePlayer.Translate(Vector3.forward * Time.deltaTime * speed);
            isGameStart = true;
            unbalanceRot += 0.0075f;
        } else
        {
            unbalanceRot = 0.125f;
        }

        if(zRot < 0)
        {
            zRotMultiply = -1;
        } else if(zRot > 0)
        {
            zRotMultiply = 1;
        }

        if (isGameStart)
        {
            zRot += unbalanceRot * zRotMultiply;
        }

        if(zRot < -45 || zRot > 45)
        {
            thePlayer.position = playerSpawn.position;
            zRot = 0;
            isGameStart = false;
        }

        thePlayer.localRotation = Quaternion.Euler(0, 90, zRot);
    }

    private void OnEnable()
    {
        playTime = 0;
    }
}
