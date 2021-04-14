using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedScore : MonoBehaviour
{
   [SerializeField] List<Text> texts;

    private void Start()
    {
        ShowPlayedValues();
    }

    private void ShowPlayedValues()
    {
       foreach(var text in texts)
       {
            var name = text.name;
            switch(name)
            {
                case "Level1PlayedTXT":
                    text.text = PlayerPrefs.GetInt("Level1Played").ToString();
                    break;
                case "Level2PlayedTXT":
                    text.text = PlayerPrefs.GetInt("Level2Played").ToString();
                    break;
                case "Level3PlayedTXT":
                    text.text = PlayerPrefs.GetInt("Level3Played").ToString();
                    break;
                case "Level4PlayedTXT":
                    text.text = PlayerPrefs.GetInt("Level4Played").ToString();
                    break;
                case "BestTimelvl1TXT":
                    text.text = PlayerPrefs.GetString("BestTimeLevel1");
                    break;
                case "BestTimelvl2TXT":
                    text.text = PlayerPrefs.GetString("BestTimeLevel2");
                    break;
                case "BestTimelvl3TXT":
                    text.text = PlayerPrefs.GetString("BestTimeLevel3");
                    break;
                case "BestTimelvl4TXT":
                    text.text = PlayerPrefs.GetString("BestTimeLevel4");
                    break;
            }
       }
    }
}
