using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBallScript : MonoBehaviour
{
    public Transform mazeObj;

    Gyroscope script_Gyro;
    public float timePlay;

    // Start is called before the first frame update
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
        timePlay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //mazeObj.Rotate(script_Gyro.rotationRateUnbiased.y * 2, 0, script_Gyro.rotationRateUnbiased.x * -2);
        mazeObj.Rotate(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
        Vector3 currentRotation = mazeObj.eulerAngles;
        mazeObj.rotation = Quaternion.Euler(currentRotation.x, 0, currentRotation.z);
        timePlay += Time.deltaTime;
    }
}
