using UnityEngine;
using System.Collections;

public class Dog : Animal
{

    private bool inWater = false;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //check to see if dog has collided with water
        if (other.gameObject.tag == "Water")
        {
            //debug message
            inWater = true;
            if(animator != null)
            {
                animator.SetBool("IsSwimming", true);
            }
        }
        base.OnTriggerEnter2D(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            if (animator != null)
            {
               // animator.SetBool("IsSwimming", false);
            }
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
