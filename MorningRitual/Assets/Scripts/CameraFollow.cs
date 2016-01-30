using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform followTransform;

	// Use this for initialization
	void Start () {
	
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
        pos.x = followTransform.position.x;
        transform.position = pos;
    }
}
