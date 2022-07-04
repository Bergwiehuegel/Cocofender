using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "First_Level_Easy";

    public SceneFader sceneFader;

    public void Play ()
    {

        Debug.Log(levelToLoad);
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit ()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void LevelOne()
    {
        levelToLoad = "First_Level_Easy";
    }

    public void LevelTwo()
    {
        levelToLoad = "First_Level_Hard";
    }

    public void LevelThree()
    {
        levelToLoad = "Second_Level_Easy";
    }

    public void LevelFour()
    {
        levelToLoad = "Second_Level_Hard";
    }
}
