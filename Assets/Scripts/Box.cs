using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool onHolder;
    private GameObject[] walls; // skup svih zidova na nivou
    private GameObject[] boxes; // skup svih kutija na nivou
   
    



    private void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        boxes = GameObject.FindGameObjectsWithTag("Box");
        OnHolder();
    }

    //pomeranje kutije
    public bool Move(Vector2 direction)
    {
        if(BoxBlocked(transform.position,direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction); //Kutija nije blokirana
            OnHolder();
            return true;
        }
    }
    // da li je kutija blokirana od strane zida ili druge kutije
    bool BoxBlocked(Vector3 position, Vector2 direction) 
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        foreach (var wall in walls)
        {
            if(wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        return false;
    }
    // da li se kutija nalazi na odredjenom cilju
    void OnHolder()
    {
        GameObject[] holders = GameObject.FindGameObjectsWithTag("Holder");
        foreach (var holder in holders)
        {
            if (transform.position.x == holder.transform.position.x && transform.position.y == holder.transform.position.y)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                onHolder = true;
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        onHolder = false;
    }
}
