
using System;
using UnityEngine;
public class BadScript : MonoBehaviour
{
    private Vector3 newPosition; // Stores the random movement values for the object
    private bool canMove = true; // Toggle that checks if the object can move

    public float maxX; // Maximum distance we can go on the X axis
    public float maxY; // Maximum distance we can go on the Y axis
    public float maxZ; // Maximum distance we can go on the Z axis

    public int counter = 0; //Number that tracks the numbers of times the object moved


    void Update()
    {
        if (Input.GetMouseButtonDown(0))     // Checks for clicks and moves the object if there is a click
        {
            DoTheMove();
        }
    }

    private void DoTheMove()
    {
        if (canMove)
        {
            newPosition = new Vector3(UnityEngine.Random.value > 0.5f ? UnityEngine.Random.Range(-maxX, maxX) : transform.position.x,  //these randoms are movement range modifiers,
                                      UnityEngine.Random.value > 0.5f ? UnityEngine.Random.Range(-maxY, maxY) : transform.position.y,  //they give a random value either positive or negative
                                      UnityEngine.Random.value > 0.5f ? UnityEngine.Random.Range(-maxZ, maxZ) : transform.position.z); //in which the player will move when clicking

            transform.position = newPosition;                  // Applies the movement to the object
            Debug.Log("We moved!");                                  // If moving is possible "We moved!" will be displayed in the console
            counter++;                                               // increase the number of times clicked for moves

            if (counter > 10)                                  //check number of times moved if over 10, stop moving
            {
                canMove = false;
            }
        }
        else
        {
            Debug.LogWarning("Can't move anymore!");                 //If moving is not possible "Can't move anymore!" will be displayed in the console            
        }
    }
}