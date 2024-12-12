using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolScript : MonoBehaviour
{
    public Transform[] spawnLocation;
    public Transform thePlayer;

    int location;

    // Start is called before the first frame update
    void Start()
    {
        location = Random.Range(0, spawnLocation.Length);

        //Debug.Log("Length = " + spawnLocation.Length + ", Random Number = " + location);

        transform.position = spawnLocation[location].localPosition;
        transform.LookAt(thePlayer);
    }
}
