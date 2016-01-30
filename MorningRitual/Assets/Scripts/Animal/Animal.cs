using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Animal : MonoBehaviour {

    [Header("Setup")]
    public Transform seatTransform;

    private bool isSeated = false;
    private Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected virtual void OnSeated()
    {

    }

    protected virtual void OnUnSeated()
    {

    }

    private void Seated()
    {
        isSeated = true;
        OnSeated();
    }

    private void Unseated()
    {
        isSeated = false;
        OnUnSeated();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.isTrigger || isSeated) return;
        Transform root = other.transform.root.transform;
        if (root.CompareTag("Player"))
        {
            playerBody = other.GetComponent<Rigidbody2D>();
            Seated();
        }
    }
}
