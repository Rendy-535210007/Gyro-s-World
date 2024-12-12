using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableArea : MonoBehaviour
{
    public RotateCupScript getTotalWater;
    public AudioSource DrinkableSFX;

    float lastPlaySFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Water")
        {
            if(Time.time - lastPlaySFX >= 0.25f)
            {
                lastPlaySFX = Time.time;
                DrinkableSFX.Play();
            }
            getTotalWater.totalWater += 5;
            Destroy(col.gameObject);
        }
    }
}
