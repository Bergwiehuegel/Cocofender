using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool GameOver = false;
    // Update is called once per frame
    void Update()
    {
        if (GameOver)
            return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("GameOver!");
        GameOver = true;
    }
}
