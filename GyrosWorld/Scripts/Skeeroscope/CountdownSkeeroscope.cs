using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSkeeroscope : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForPlayerUIShowUp());
    }

    void OnEnable()
    {
        StartCoroutine(WaitForPlayerUIShowUp());
    }

    IEnumerator WaitForPlayerUIShowUp()
    {
        yield return new WaitForSeconds(4f);
        playerUI.SetActive(true);
        gameController.SetActive(true);
    }
}
