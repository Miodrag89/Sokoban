using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) <= 0.5) //Uvek ce postaviti jednu od kordinata na 0
        {                                 // da se ne bi kretao dijagonalno
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize(); // Postavlja ili x ili y na 1
        if(Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            FindObjectOfType<Igra>().AddAction();
            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
