using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    float theTime;
    float speed = 1f;
    bool playing;
    float floatSeconds;
    float floatMinutes;
    float comparingValue; // vrednost koja ce odluciti koji string ce biti sacuvan
    string currentTime;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Playing();
    }

    public void StartTimer()
    {
        playing = true;
    }

    public void StopTimer()
    {
        playing = false;
    }

    private void Playing()
    {
        if (playing)
        {
            TimerCounting();
        }
        else
        {
            SaveBestTime();
        }
    }

    private void TimerCounting()
    {
        theTime += Time.deltaTime * speed;
        //string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");  //Za sate ako je potrebno
        floatSeconds = (theTime % 60);
        floatMinutes = Mathf.Floor((theTime % 3600) / 60);
        comparingValue = (floatMinutes * 60) + floatSeconds;
        string minutes = floatMinutes.ToString("00");
        string seconds = floatSeconds.ToString("00");
        currentTime = minutes + ":" + seconds;
        text.text = currentTime;
    }

    private void SaveBestTime()
    {
        int index = FindObjectOfType<SceneLoader>().CurrentScene;
        switch(index)
        {
            case 1:
                Saving("BestTimeLevel1", "ComparingValueLevel1");
                break;
            case 2:
                Saving("BestTimeLevel2", "ComparingValueLevel2");
                break;
            case 3:
                Saving("BestTimeLevel3", "ComparingValueLevel3");
                break;
            case 4:
                Saving("BestTimeLevel4", "ComparingValueLevel4");
                break;
        }
    }

    private void Saving(string keyName, string compare)
    {
        if (!PlayerPrefs.HasKey(keyName) && !PlayerPrefs.HasKey(compare))
        {
            PlayerPrefs.SetFloat(compare, comparingValue);
            PlayerPrefs.SetString(keyName, currentTime);
        }
        else
        {
            if(comparingValue <= PlayerPrefs.GetFloat(compare))
            {
                PlayerPrefs.SetFloat(compare, comparingValue);
                PlayerPrefs.SetString(keyName, currentTime);
            }
        }
    }
}
