using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int[] scores;
    [SerializeField] private Text[] scoreTexts;

    [SerializeField] private int maxScore;
    public bool gameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerID)
    {
        int playerIndex = playerID - 1; // Get player index for array
        scores[playerIndex]++;
        scoreTexts[playerIndex].text = "Player " + playerID + ": " + scores[playerIndex];

        // If a player has won, then victory!
        if (scores[playerIndex] == maxScore)
        {
            GameOver(playerID);
        }
    }

    public void GameOver(int winnerID)
    {
        Debug.Log("Player " + winnerID + " wins!");
        gameActive = false;
        Time.timeScale = 0;
    }
}
