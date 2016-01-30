using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerController1))]
public class Animal : MonoBehaviour {

    [Header("Setup")]
    public Transform seatTransform;

    private bool isSeated = false;
    private Transform playerTransform;
    private PlayerController1 playerController;

    private PlayerController1 animalController;

    // Use this for initialization
    protected virtual void Awake()
    {
        animalController = GetComponent<PlayerController1>();
        animalController.enabled = false;
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (isSeated)
        {
            //if(playerController)
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
        animalController.enabled = true;
        playerController.enabled = false;
        OnSeated();
    }

    private void Unseated()
    {
        isSeated = false;
        playerTransform.SetParent(null, false);
        animalController.enabled = false;
        playerController.enabled = true;
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
