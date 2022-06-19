using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public SceneFader sceneFader;

    void OnEnable()
    {
        roundsText.text = "Test";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() 
    {
        Debug.Log("Go to Main Menu");
        sceneFader.FadeTo("Main_Menu");
    }

}
