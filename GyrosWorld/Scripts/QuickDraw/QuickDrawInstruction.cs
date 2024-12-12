using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDrawInstruction : MonoBehaviour
{
    public GameObject gameController;
    public GameObject playerUI;

    // Start is called before the first frame update
    void Start()
    {
        gameController.SetActive(true);
        playerUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
