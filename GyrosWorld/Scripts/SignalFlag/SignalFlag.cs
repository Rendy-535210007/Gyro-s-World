using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignalFlag : MonoBehaviour
{
    public GameObject timer;
    public FlagScript getFlagPos;
    public TextMeshProUGUI commandText;
    public Image commandImg;
    public TextMeshProUGUI timerText;
    public Transform theFlag;
    public GameObject playerUI;
    public GameObject EndUI;
    public TextMeshProUGUI totalPointText;
    public TextMeshProUGUI playerText;
    public AudioSource voiceCommand;
    public AudioClip maleUp;
    public AudioClip maleLeft;
    public AudioClip maleRight;
    public AudioClip maleDown;
    public AudioClip femaleUp;
    public AudioClip femaleLeft;
    public AudioClip femaleRight;
    public AudioClip femaleDown;

    int point = 0;
    float cooldown = 2.5f;
    float lastCommand = 0;
    float playTime = 30;
    Gyroscope script_Gyro;
    int command = 0;
    // male = true direction. female = opposite direction
    // 1 = up, male
    // 2 = left, male
    // 3 = right, male
    // 4 = bottom, male
    // 5 = up, female
    // 6 = left, female
    // 7 = right, female
    // 8 = bottom, female
    // male = yellow, female = red

    
    void Start()
    {
        script_Gyro = Input.gyro;
        script_Gyro.enabled = true;
        playerUI.SetActive(true);
        playTime = 30;
        timer.SetActive(true);
    }

    void Update()
    {
        //theFlag.rotation = script_Gyro.attitude;
        theFlag.Rotate(0, 0, script_Gyro.rotationRateUnbiased.z * 2);
        //theFlag.Rotate(0, 0, -Input.GetAxis("Mouse X") * 100 * Time.deltaTime);

        playTime -= Time.deltaTime;
        timerText.text = playTime.ToString("F2");

        if(playTime <= 0)
        {
            // game is over
            EndUI.SetActive(true);
            totalPointText.text = point.ToString("F0");
            int getcurPlayer = PlayerPrefs.GetInt("CurPlayer");
            playerText.text = PlayerPrefs.GetString("NameP" + getcurPlayer.ToString());
            PlayerPrefs.SetFloat("ScoreP" + getcurPlayer.ToString(), point);
            Destroy(playerUI);
            Destroy(gameObject);
        }
        else
        {
            // game is running
            if(Time.time - lastCommand >= cooldown)
            {
                lastCommand = Time.time;
                cooldown = Mathf.Clamp(cooldown - 0.05f, 1.25f, 2.5f);
                
                // Checking command before
                switch(command)
                {
                    case 1:
                        if(getFlagPos.flagPos == 1)
                        {
                            point += 1;
                        }
                        break;
                    case 2:
                        if (getFlagPos.flagPos == 2)
                        {
                            point += 1;
                        }
                        break;
                    case 3:
                        if (getFlagPos.flagPos == 3)
                        {
                            point += 1;
                        }
                        break;
                    case 4:
                        if (getFlagPos.flagPos == 4)
                        {
                            point += 1;
                        }
                        break;
                    case 5:
                        if (getFlagPos.flagPos == 4)
                        {
                            point += 1;
                        }
                        break;
                    case 6:
                        if (getFlagPos.flagPos == 3)
                        {
                            point += 1;
                        }
                        break;
                    case 7:
                        if (getFlagPos.flagPos == 2)
                        {
                            point += 1;
                        }
                        break;
                    case 8:
                        if (getFlagPos.flagPos == 1)
                        {
                            point += 1;
                        }
                        break;
                    default:
                        break;
                }

                randomCommand();
            }
        }
    }

    void randomCommand()
    {
        // random command from 1-8
        command = Random.Range(1, 9);
        switch (command)
        {
            case 1:
                commandText.text = "UP";
                commandImg.color = Color.yellow;
                voiceCommand.clip = maleUp;
                voiceCommand.Play();
                break;
            case 2:
                commandText.text = "LEFT";
                commandImg.color = Color.yellow;
                voiceCommand.clip = maleLeft;
                voiceCommand.Play();
                break;
            case 3:
                commandText.text = "RIGHT";
                commandImg.color = Color.yellow;
                voiceCommand.clip = maleRight;
                voiceCommand.Play();
                break;
            case 4:
                commandText.text = "DOWN";
                commandImg.color = Color.yellow;
                voiceCommand.clip = maleDown;
                voiceCommand.Play();
                break;
            case 5:
                commandText.text = "UP";
                commandImg.color = Color.red;
                voiceCommand.clip = femaleUp;
                voiceCommand.Play();
                break;
            case 6:
                commandText.text = "LEFT";
                commandImg.color = Color.red;
                voiceCommand.clip = femaleLeft;
                voiceCommand.Play();
                break;
            case 7:
                commandText.text = "RIGHT";
                commandImg.color = Color.red;
                voiceCommand.clip = femaleRight;
                voiceCommand.Play();
                break;
            case 8:
                commandText.text = "DOWN";
                commandImg.color = Color.red;
                voiceCommand.clip = femaleDown;
                voiceCommand.Play();
                break;
            default:
                break;
        }
    }
}
