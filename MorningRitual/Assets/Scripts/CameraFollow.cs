using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    private Transform followTransform;

    [Header("Configure")]
    public float applySpeed = 1;
    public float ySnap = 2.0f;
    public Vector2 min;
    public Vector2 max;

    private int yHeight = 0;

	// Use this for initialization
	void Awake () {
        followTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if(followTransform)
        {
            Vector3 pos = followTransform.position;
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, followTransform.position.x, Time.fixedDeltaTime * applySpeed);
        if (Mathf.Abs(followTransform.position.y - transform.position.y + yHeight) > ySnap)
        {
            pos.y = Mathf.Lerp(transform.position.y, followTransform.position.y + ySnap, Time.fixedDeltaTime * Mathf.Abs(followTransform.position.y - transform.position.y + yHeight));
        }
        else
        {
            yHeight += 1;
            transform.position = new Vector2(transform.position.x, followTransform.position.y + ySnap);
        }
        transform.position = pos;
    }
}
