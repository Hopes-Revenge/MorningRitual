using UnityEngine;
using System.Collections;

public class Dog : Animal
{

    private bool inWater = false;

    void OnTriggerEnter2D(Collider2D other)
    {

        //check to see if dog has collided with water
        if (other.gameObject.tag == "Water")
        {
            //debug message
            print("Here.");
            inWater = true;

        }
    }

    protected override void OnSeated()
    {
        //gameObject.GetComponent<AudioSource>().PlayOneShot(seatedSounds[Random.Range(0, seatedSounds.Length)]);
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Water" && isSeated)
        {
            //gameObject.GetComponent<AudioSource>().PlayOneShot(activatedSounds[Random.Range(0, activatedSounds.Length)]);
        }
    }
}
