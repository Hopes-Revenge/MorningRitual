using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour {

    Vector2 basePosition;
    bool isSinking = false;
    float i = 0.0f;
    float q = 0.0f;

	// Use this for initialization
	void Start ()
    {
        basePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            isSinking = true;
            float t = 0.0f;
            /*
            while (t < 1.0f)
            {
                t += Time.deltaTime * 0.1f;
                transform.position = Vector2.Lerp(basePosition, new Vector2(basePosition.x, basePosition.y - 0.5f), t);
            }*/
        }
    }

    /*
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isSinking = false;
            float t = Time.deltaTime * 0.1f;
            transform.position = Vector2.Lerp(basePosition, new Vector2(basePosition.x, basePosition.y - 0.5f), t);
        }
    }*/
}
