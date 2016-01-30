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
        if (Mathf.Abs(followTransform.position.y - transform.position.y) > 1.75f)
        {
            pos.y = Mathf.Lerp(transform.position.y, followTransform.position.y + 1.75f, Time.fixedDeltaTime * Mathf.Abs(followTransform.position.y - transform.position.y));
        }
        else
        {
            transform.position = new Vector2(transform.position.x, followTransform.position.y + 1.75f);
        }
        transform.position = pos;
    }
}
