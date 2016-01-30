using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [Header("Setup")]
    public Transform followTransform;

    [Header("Configure")]
    public float applySpeed = 1;

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
        pos.x = Mathf.Lerp(transform.position.x, followTransform.position.x, Time.fixedDeltaTime * applySpeed);
        transform.position = pos;
    }
}
