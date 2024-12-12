using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlagScript : MonoBehaviour
{
    [HideInInspector] public int flagPos = 1;
    // up     = 1
    // left   = 2
    // right  = 3
    // bottom = 4
    public TextMeshProUGUI flagPosText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Up")
        {
            flagPos = 1;
            flagPosText.text = "Up";
        }
        else if (other.gameObject.tag == "Left")
        {
            flagPos = 2;
            flagPosText.text = "Left";
        }
        else if (other.gameObject.tag == "Right")
        {
            flagPos = 3;
            flagPosText.text = "Right";
        }
        else if (other.gameObject.tag == "Bottom")
        {
            flagPos = 4;
            flagPosText.text = "Down";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Up" || other.gameObject.tag == "Left" || other.gameObject.tag == "Right" || other.gameObject.tag == "Bottom")
        {
            flagPos = 0;
        }
    }
}
