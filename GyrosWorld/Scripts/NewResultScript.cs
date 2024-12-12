using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewResultScript : MonoBehaviour
{
    List<int> sortedPlayerIndex = new List<int> { };
    public TextMeshProUGUI playerName1;
    public TextMeshProUGUI playerName2;
    public TextMeshProUGUI playerName3;
    public TextMeshProUGUI playerName4;
    public TextMeshProUGUI playerName5;
    public TextMeshProUGUI playerName6;
    public TextMeshProUGUI playerScore1;
    public TextMeshProUGUI playerScore2;
    public GameObject rank2;
    public TextMeshProUGUI playerScore3;
    public GameObject rank3;
    public TextMeshProUGUI playerScore4;
    public GameObject rank4;
    public TextMeshProUGUI playerScore5;
    public GameObject rank5;
    public TextMeshProUGUI playerScore6;
    public GameObject rank6;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
        List<(float score, int index)> listScoreTemp = new List<(float, int)>();

        for(int i = 1; i <= 6; i++)
        {
            if(PlayerPrefs.GetString("NameP" + i) != "")
            {
                listScoreTemp.Add((PlayerPrefs.GetFloat("ScoreP" + i), i));
            }
        }

        for(int i = 0; i < listScoreTemp.Count; i++)
        {
            sortedPlayerIndex.Add(0);
        }

        if(PlayerPrefs.GetInt("ScoreAsc") == 0)
        {
            for (int i = 0; i < listScoreTemp.Count; i++)
            {
                Debug.Log(i);
                if (listScoreTemp[i].score < 0)
                {
                    for(int j = listScoreTemp.Count - 1; j > i; j--)
                    {
                        if (sortedPlayerIndex[j] == 0)
                        {
                            sortedPlayerIndex[j] = i + 1;
                            listScoreTemp.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        if (PlayerPrefs.GetInt("ScoreAsc") == 0)
        {
            for (int i = 0; i < listScoreTemp.Count; i++)
            {
                sortedPlayerIndex[i] = listScoreTemp.OrderByDescending(x => x.score).First().index;
                //listScoreTemp.RemoveAt(listScoreTemp.OrderByDescending(x => x.score).First().index);
                
                //listScoreTemp.RemoveAt(listScoreTemp
                //    .Where(x => x.score == listScoreTemp.Max(y => y.score))
                //    .Select(x => listScoreTemp.IndexOf(x))
                //    .First());
                
                //sortedPlayerIndex[i] = listScoreTemp.IndexOf(listScoreTemp.Max());
                //listScoreTemp.RemoveAt(listScoreTemp.IndexOf(listScoreTemp.Max()));
            }
        } else
        {
            for (int i = 0; i < listScoreTemp.Count; i++)
            {
                sortedPlayerIndex[i] = listScoreTemp.OrderBy(x => x.score).First().index;
                listScoreTemp.RemoveAt(listScoreTemp.OrderBy(x => x.score).First().index);
                
                //listScoreTemp.RemoveAt(listScoreTemp
                //    .Where(x => x.score == listScoreTemp.Min(y => y.score))
                //    .Select(x => listScoreTemp.IndexOf(x))
                //    .First());
                
                //sortedPlayerIndex[i] = listScoreTemp.IndexOf(listScoreTemp.Min());
                //listScoreTemp.RemoveAt(listScoreTemp.IndexOf(listScoreTemp.Min()));
            }
        }

        //Debug.Log(sortedPlayerIndex[0]);
        //Debug.Log(sortedPlayerIndex[1]);
        //Debug.Log(sortedPlayerIndex[2]);
        //Debug.Log(sortedPlayerIndex[3]);
        //Debug.Log(sortedPlayerIndex[4]);

        playerName1.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[0]) + " :";
        playerScore1.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[0]).ToString("F3");

        if(sortedPlayerIndex.Count >= 2)
        {
            playerName2.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[1]) + " :";
            playerScore2.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[1]).ToString("F3");
        } else
        {
            playerName2.text = "";
            playerScore2.text = "";
            rank2.SetActive(false);
        }

        if (sortedPlayerIndex.Count >= 3)
        {
            playerName3.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[2]) + " :";
            playerScore3.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[2]).ToString("F3");
        }
        else
        {
            playerName3.text = "";
            playerScore3.text = "";
            rank3.SetActive(false);
        }

        if (sortedPlayerIndex.Count >= 4)
        {
            playerName4.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[3]) + " :";
            playerScore4.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[3]).ToString("F3");
        }
        else
        {
            playerName4.text = "";
            playerScore4.text = "";
            rank4.SetActive(false);
        }

        if (sortedPlayerIndex.Count >= 5)
        {
            playerName5.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[4]) + " :";
            playerScore5.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[4]).ToString("F3");
        }
        else
        {
            playerName5.text = "";
            playerScore5.text = "";
            rank5.SetActive(false);
        }

        if (sortedPlayerIndex.Count >= 6)
        {
            playerName6.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[5]) + " :";
            playerScore6.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[5]).ToString("F3");
        }
        else
        {
            playerName6.text = "";
            playerScore6.text = "";
            rank6.SetActive(false);
        }
        
    }

    */

    void Start()
    {
        List<(float score, int index)> listScoreTemp = new List<(float, int)>();

        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetString("NameP" + i) != "")
            {
                listScoreTemp.Add((PlayerPrefs.GetFloat("ScoreP" + i), i));
            }
        }

        // Split the players into those with score >= 0 and those with score < 0
        var positiveScores = listScoreTemp.Where(x => x.score >= 0).ToList();
        var negativeScores = listScoreTemp.Where(x => x.score < 0).ToList();

        bool isScoreAscending = PlayerPrefs.GetInt("ScoreAsc") == 0;

        // If ScoreAsc == 0, sort the positive scores from lowest to highest, 
        // else sort from highest to lowest.
        if (isScoreAscending)
        {
            // Sort positive scores in ascending order
            positiveScores = positiveScores.OrderBy(x => x.score).ToList();
        }
        else
        {
            // Sort positive scores in descending order
            positiveScores = positiveScores.OrderByDescending(x => x.score).ToList();
            negativeScores = negativeScores.OrderByDescending(x => x.score).ToList();
        }

        // Concatenate the sorted positive scores with the negative scores at the end
        listScoreTemp = positiveScores.Concat(negativeScores).ToList();

        // Clear the sortedPlayerIndex list and fill it with the sorted indices
        sortedPlayerIndex.Clear();
        foreach (var player in listScoreTemp)
        {
            sortedPlayerIndex.Add(player.index);
        }

        // Display the player details for top 6 players
        SetPlayerDetails(0, playerName1, playerScore1, rank2);
        SetPlayerDetails(1, playerName2, playerScore2, rank2);
        SetPlayerDetails(2, playerName3, playerScore3, rank3);
        SetPlayerDetails(3, playerName4, playerScore4, rank4);
        SetPlayerDetails(4, playerName5, playerScore5, rank5);
        SetPlayerDetails(5, playerName6, playerScore6, rank6);
    }

    private void SetPlayerDetails(int index, TextMeshProUGUI playerName, TextMeshProUGUI playerScore, GameObject rank)
    {
        if (index < sortedPlayerIndex.Count)
        {
            playerName.text = PlayerPrefs.GetString("NameP" + sortedPlayerIndex[index]) + " :";
            if(PlayerPrefs.GetInt("ScoreAsc") == 0 && PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[index]) < 0)
            {
                playerScore.text = "LOSE";
            }
            else
            {
                playerScore.text = PlayerPrefs.GetFloat("ScoreP" + sortedPlayerIndex[index]).ToString("F3");
            }
            rank.SetActive(true);
        }
        else
        {
            playerName.text = "";
            playerScore.text = "";
            rank.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
