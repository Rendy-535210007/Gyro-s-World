using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDrinkableArea : MonoBehaviour
{
    public RotateCupScript getTotalWater;
    public AudioSource notDrinkableSFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Water")
        {
            notDrinkableSFX.Play();
            getTotalWater.totalWater -= 10;
            Destroy(col.gameObject);
        }
    }
}
