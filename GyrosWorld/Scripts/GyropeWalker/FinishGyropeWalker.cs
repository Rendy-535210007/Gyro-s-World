using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGyropeWalker : MonoBehaviour
{
    public GameObject gameController;
    public GameObject endUI;
    public Text playTimeText;
    public Text playerText;
    public GyropeWalkerScript getPlayTime;
    public AudioSource winSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.SetActive(false);
            endUI.SetActive(true);
            playTimeText.text = getPlayTime.playTime.ToString("F3");
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), getPlayTime.playTime);
            winSFX.Play();
        }
    }
}
