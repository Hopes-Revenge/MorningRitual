using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

    private float cloudSpeed = 0.01f;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    //if(GetComponentInChildren<Transform>().position.x - transform.position.x < -20.0f){}
        foreach(Transform child in gameObject.transform)
        {
            if(child.position.x - transform.position.x < -20.0f)
            {
                child.position = new Vector2(Random.Range(20.0f, 100.0f), Random.Range(-20.0f, 20.0f));
            }
            else
            {
                child.position = new Vector2(child.position.x - cloudSpeed, child.position.y);
            }
        }
	}
}
