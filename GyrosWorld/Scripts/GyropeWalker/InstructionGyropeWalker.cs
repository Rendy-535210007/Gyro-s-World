using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionGyropeWalker : MonoBehaviour
{
    public GameObject gameController;
    public GameObject countdownUI;
    public AudioSource countdownAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameController.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartTheGame()
    {
        countdownUI.SetActive(true);
        countdownAudio.Play();
        Destroy(gameObject);
    }
}
