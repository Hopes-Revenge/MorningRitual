using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<AudioSource>().PlayOneShot(other.GetComponent<PlayerController1>().squakSounds[Random.Range(0, other.GetComponent<PlayerController1>().squakSounds.Length)]);
        }
        //find the GameManager
        GameManager gm = GameObject.FindObjectOfType<GameManager>();

        //set the found egg = true
        gm.foundEgg = true;

        //destroy the collectable
        Destroy(this.gameObject);
    }
}
