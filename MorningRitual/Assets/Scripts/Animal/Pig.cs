using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour {

    public float sinkScale = 0.5f;
    public float raiseScale = 0.2f;

    Vector2 basePosition;
    bool isSinking = false;
    bool sunk = false;
    float i = 0.0f;
    float q = 0.0f;
    float t = 0.0f;

    // Use this for initialization
    void Start ()
    {
        basePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isSinking)
        {
            if (t < 1.0f)
            {
                t += Time.deltaTime * sinkScale;
            }
        }
        else if(!isSinking)
        {
            if (t > 0.0f)
            {
                t -= Time.deltaTime * raiseScale;
            }
        }

        transform.position = Vector2.Lerp(basePosition, new Vector2(basePosition.x, basePosition.y - 1.0f), t);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            isSinking = true;
            sunk = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isSinking = false;
        }
    }
}
