using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    public GameObject gameController;
    public TextMeshProUGUI countdownText;

    float countdownTimeEnd;
    float countdownTime;

    private void Start()
    {
        countdownTimeEnd = Time.time + 3.5f;
        StartCoroutine(SetStartTheGame());
    }

    // Update is called once per frame
    void Update()
    {
        countdownTime = countdownTimeEnd - Time.time;
        if(countdownTime < 0.5f)
        {
            countdownText.text = "START!";
        } else
        {
            countdownText.text = countdownTime.ToString("F0");
        }
        
    }

    IEnumerator SetStartTheGame()
    {
        yield return new WaitForSeconds(4f);
        gameController.SetActive(true);
        Destroy(gameObject);
    }
}
