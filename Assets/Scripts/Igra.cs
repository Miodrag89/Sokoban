using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Igra : MonoBehaviour
{
    private bool readyForInput;
    public Player player;
    GameObject nextLevel;
    int numberOfActions;
    bool freeze; // u slucaju da je resen nivo postace true i onemoguciti kretanje igraca

    private void Start()
    {
        nextLevel = GameObject.FindGameObjectWithTag("Next");
        nextLevel.SetActive(false); // postavljanje next level buttona na false na pocetku igre
        FindObjectOfType<Timer>().StartTimer();
        freeze = false;
    }
    private void Update()
    {
        if(!freeze)
        {
            float moveX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float moveY = CrossPlatformInputManager.GetAxisRaw("Vertical");
            Vector2 moveInput = new Vector2(moveX, moveY);
            moveInput.Normalize();
            if (moveInput.sqrMagnitude > 0.5)
            {
                if (readyForInput)
                {
                    readyForInput = false;
                    player.Move(moveInput);
                }
            }
            else
            {
                readyForInput = true;
            }
            if (IsLevelComplete())
            {
                nextLevel.SetActive(true);
                FindObjectOfType<Timer>().StopTimer();
                freeze = true;
                return;
            }
        }
    }

    public void AddAction()
    {
        numberOfActions++;
    }

    public int ActionCounter()
    {
        return numberOfActions;
    }

    public void ResetCounter()
    {
        numberOfActions = 0;
    }

    bool IsLevelComplete()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach(var box in boxes)
        {
            if(!box.onHolder)
            {
                return false;
            }
        }
        return true;
    }
    
}
