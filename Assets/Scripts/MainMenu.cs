using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "First_Level";

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
}
