using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingingScript : MonoBehaviour
{
    public GameObject RingingAlert;
    bool isUp;

    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            RingingAlert.transform.position = new Vector3(-2.34f, 1.2f, -6f);
            isUp = false;
        }
        else
        {
            RingingAlert.transform.position = new Vector3(-2.34f, 1.23f, -6f);
            isUp = true;
        }
    }
}
