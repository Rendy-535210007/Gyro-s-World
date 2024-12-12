using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestingGryoScipt : MonoBehaviour
{
    
    public GameObject gyroAtd_x;
    public GameObject gyroAtd_y;
    public GameObject gyroAtd_z;
    public GameObject gyroRotRate_x;
    public GameObject gyroRotRate_y;
    public GameObject gyroRotRate_z;
    public GameObject gyroAtd_low;
    public GameObject gyroAtd_high;
    public GameObject gyroRotRate_low;
    public GameObject gyroRotRate_high;

    TextMeshPro textgyroAtd_X;
    TextMeshPro textgyroAtd_Y;
    TextMeshPro textgyroAtd_Z;
    TextMeshPro textgyroRotRate_X;
    TextMeshPro textgyroRotRate_Y;
    TextMeshPro textgyroRotRate_Z;
    TextMeshPro textgyroAtd_low;
    TextMeshPro textgyroAtd_high;
    TextMeshPro textgyroRotRate_low;
    TextMeshPro textgyroRotRate_high;

    float minAtd = 10;
    float maxAtd = -10;
    float minRotRate = 10;
    float maxRotRate = -10;

    //Quaternion newQuaternion = new Quaternion();
    Gyroscope script_Gyro;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;

        
        textgyroAtd_X = gyroAtd_x.GetComponent<TextMeshPro>();
        textgyroAtd_Y = gyroAtd_y.GetComponent<TextMeshPro>();
        textgyroAtd_Z = gyroAtd_z.GetComponent<TextMeshPro>();
        textgyroRotRate_X = gyroRotRate_x.GetComponent<TextMeshPro>();
        textgyroRotRate_Y = gyroRotRate_y.GetComponent<TextMeshPro>();
        textgyroRotRate_Z = gyroRotRate_z.GetComponent<TextMeshPro>();
        textgyroAtd_low = gyroAtd_low.GetComponent<TextMeshPro>();
        textgyroAtd_high = gyroAtd_high.GetComponent<TextMeshPro>();
        textgyroRotRate_low = gyroRotRate_low.GetComponent<TextMeshPro>();
        textgyroRotRate_high = gyroRotRate_high.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //newQuaternion.Set(script_Gyro.attitude.x * -1, 0, script_Gyro.attitude.y * -1, 1);

        //transform.localRotation = newQuaternion;

        if(script_Gyro.attitude.x < minAtd)
        {
            minAtd = script_Gyro.attitude.x;
            textgyroAtd_low.text = "GyroAtd_Lowest: " + script_Gyro.attitude.x.ToString();
        }

        if (script_Gyro.attitude.x > maxAtd)
        {
            maxAtd = script_Gyro.attitude.x;
            textgyroAtd_high.text = "GyroAtd_Highest: " + script_Gyro.attitude.x.ToString();
        }

        if (script_Gyro.rotationRate.x < minRotRate)
        {
            minRotRate = script_Gyro.rotationRate.x;
            textgyroRotRate_low.text = "GyroRotRate_Lowest: " + script_Gyro.rotationRate.x.ToString();
        }

        if (script_Gyro.rotationRate.x > maxRotRate)
        {
            maxRotRate = script_Gyro.rotationRate.x;
            textgyroRotRate_high.text = "GyroRotRate_Highest: " + script_Gyro.rotationRate.x.ToString();
        }

        textgyroAtd_X.text = "GyroAtd_X: " + script_Gyro.attitude.x.ToString();
        textgyroAtd_Y.text = "GyroAtd_Y: " + script_Gyro.attitude.y.ToString();
        textgyroAtd_Z.text = "GyroAtd_Z: " + script_Gyro.attitude.z.ToString();
        textgyroRotRate_X.text = "GyroRotRate_X: " + script_Gyro.rotationRate.x.ToString();
        textgyroRotRate_Y.text = "GyroRotRate_Y: " + script_Gyro.rotationRate.y.ToString();
        textgyroRotRate_Z.text = "GyroRotRate_Z: " + script_Gyro.rotationRate.z.ToString();
        
    }
}
