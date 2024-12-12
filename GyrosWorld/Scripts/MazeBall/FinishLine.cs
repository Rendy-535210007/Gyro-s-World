using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject endUI;
    public Text timeText;
    public MazeBallScript getMazeScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timeText.text = getMazeScript.timePlay.ToString("F3");
        }
    }
}
