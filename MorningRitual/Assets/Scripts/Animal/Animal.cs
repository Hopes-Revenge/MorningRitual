using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Animal : MonoBehaviour {

    [Header("Setup")]
    public Transform seatTransform;

    private bool isSeated = false;
    private Transform playerTransform;
    private PlayerController1 playerController;

    // Use this for initialization
    protected virtual void Awake()
    {

    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (isSeated)
        {
            
        }
	}

    void LateUpdate()
    {
        if (isSeated)
        {
            playerTransform.position = seatTransform.position;
        }
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
        playerTransform.SetParent(seatTransform, false);
        OnSeated();
    }

    private void Unseated()
    {
        isSeated = false;
        playerTransform.SetParent(null, false);
        OnUnSeated();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.isTrigger || isSeated) return;
        Transform root = other.transform.root.transform;
        Debug.Log(root.tag);
        if (root.CompareTag("Player"))
        {
            playerTransform = root;
            playerController = root.GetComponent<PlayerController1>();
            Seated();
        }
    }
}
