using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float gyroSens = 1;
    public Transform playerBody;
    public Camera mainCam;

    Gyroscope script_Gyro;
    float xRotation = 0f;
    float gyroX = 0;
    float gyroY = 0;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        gyroX = -script_Gyro.rotationRateUnbiased.x * gyroSens * Time.deltaTime * 100;
        gyroY = -script_Gyro.rotationRateUnbiased.y * gyroSens * Time.deltaTime * 100;

        //gyroX = -Input.GetAxis("Mouse Y");
        //gyroY = Input.GetAxis("Mouse X");

        xRotation += gyroX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * gyroY);
    }
}
