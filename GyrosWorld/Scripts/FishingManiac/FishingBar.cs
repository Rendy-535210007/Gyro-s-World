using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBar : MonoBehaviour
{
    [HideInInspector] public bool isGetTheFish = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            isGetTheFish = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isGetTheFish = false;
        }
    }
}
