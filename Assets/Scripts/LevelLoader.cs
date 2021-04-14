using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentScene;
    int numberOfPlaysIncrement; // broj koji predstavlja povecanje broja koliko je puta odigran odredjeni nivo




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
        numberOfPlaysIncrement++; // povecava se sa 0 na 1 kako bi se povecala vrednost unutar odredjenog key-a za 1
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
            var newValue = PlayerPrefs.GetInt(keyName) + numberOfPlaysIncrement; // nova vrednost za snimanje
            PlayerPrefs.SetInt(keyName, newValue);
        }
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(currentScene + 2);
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(currentScene + 3);
    }

    public void LoadLevelFour()
    {
        SceneManager.LoadScene(currentScene + 4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
