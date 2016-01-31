using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Here.");

        //change the bool here
        Destroy(this.gameObject);

    }
}
