using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentScene;
    int numberOfPlaysIncrement = 1; // broj koji predstavlja povecanje broja koliko je puta odigran odredjeni nivo
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 0)
        {
            SaveLevelEntry();
        }
    }

    private void SaveLevelEntry()
    {
        switch (currentScene)
        {
            case 1:
                Saving("Level1Played");
                break;
            case 2:
                Saving("Level2Played");
                break;
            case 3:
                Saving("Level3Played");
                break;
            case 4:
                Saving("Level4Played");
                break;
        }
    }

    private void Saving(string keyName)
    {
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, numberOfPlaysIncrement);
        }
        else
        {
            var newValue = PlayerPrefs.GetInt(keyName) + numberOfPlaysIncrement;
            PlayerPrefs.SetInt(keyName, newValue);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
        FindObjectOfType<Igra>().ResetCounter();
    }
    public void ResetCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
        FindObjectOfType<Igra>().ResetCounter();
    }

    public void LoadStartingScene()
    {
        SceneManager.LoadScene(currentScene - currentScene);
        FindObjectOfType<Igra>().ResetCounter();
    }

    public int CurrentScene => currentScene;
}
