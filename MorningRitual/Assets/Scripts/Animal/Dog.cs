using UnityEngine;
using System.Collections;

public class Dog : Animal {

    private bool inWater = false;

    void OnTriggerEnter2D(Collider2D other)
    {
    
        //check to see if dog has collided with water
        if (other.gameObject.tag == "Water")
        {
            //debug message
            print("Here.");

        }
    }

}
