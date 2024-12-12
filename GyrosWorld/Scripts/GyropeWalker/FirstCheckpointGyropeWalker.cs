using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheckpointGyropeWalker : MonoBehaviour
{
    public GyropeWalkerScript getgameStart;
    public Transform spawnLocation;
    public Transform playerParent;
    public GameObject gameController;
    public GameObject startButton;
    public AudioClip instructionComplete;
    public AudioSource getAudioSource;

    private Vector3 gameSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        gameSpawnLocation = new Vector3(-5.75f, 6.533f, -8.88f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            getgameStart.isGameStart = false;
            playerParent.localRotation = Quaternion.Euler(0, 90, 0);
            spawnLocation.position = gameSpawnLocation;
            playerParent.position = gameSpawnLocation;
            gameController.SetActive(false);
            startButton.SetActive(true);
            getAudioSource.clip = instructionComplete;
            getAudioSource.Play();
        }
    }
}
