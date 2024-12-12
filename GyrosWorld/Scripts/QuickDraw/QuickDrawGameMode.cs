using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDrawGameMode : MonoBehaviour
{
    [HideInInspector]
    public bool isStart = false;
    [HideInInspector]
    public float playTime = 0;

    private void Update()
    {
        if(isStart)
        {
            playTime += Time.deltaTime;
        }
    }
}
