using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCounter : MonoBehaviour
{
    Text text; // tekstualni prikaz broja poteza igraca
    Igra igra;

    public void Start()
    {
        text = GetComponent<Text>();
        igra = FindObjectOfType<Igra>();
    }

    public void Update()
    {
        Writing();
    }

    private void Writing()
    {
        text.text = igra.ActionCounter().ToString();
    }
}
