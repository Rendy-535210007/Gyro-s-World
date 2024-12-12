using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionNotDrinkableArea : MonoBehaviour
{
    public DrinkContestInstruction getTotalWater;
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
