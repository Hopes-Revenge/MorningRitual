﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerController1))]
public class Animal : MonoBehaviour {

    [Header("Setup")]
    public Transform seatTransform;

    [Header("Configure")]
    public float jumpOffAddY = 0.2f;

    protected bool isSeated = false;
    private Transform playerTransform;
    private PlayerController1 playerController;
    private float originalScale = 1;

    private Rigidbody2D body;
    protected Animator animator;
    private PlayerController1 animalController;

    public AudioClip[] seatedSounds;
    public AudioClip[] activatedSounds;

    // Use this for initialization
    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animalController = GetComponent<PlayerController1>();
        animalController.enabled = false;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (isSeated)
        {
            if(Input.GetButtonDown("ActivateAnimal"))
            {
                if(animator != null)
                {
                    animator.SetTrigger("Activate");
                }
                Activated();
            }
            if(Input.GetButton("ActivateAnimal"))
            {
                ContinualUse();
            }
            if(Input.GetButtonUp("ActivateAnimal"))
            {
                Deactivated();
            }
            if(playerController.GetIsJumping())
            {
                Unseated();
                return;
            }
        } else if(body != null) {
            body.velocity = new Vector2(0, body.velocity.y);
        }
	}

    void LateUpdate()
    {
		if (isSeated && playerTransform != null)
        {
            playerTransform.position = seatTransform.position;
            Vector3 scale = playerTransform.localScale;
            float sign = Mathf.Sign(transform.localScale.x);
            scale.x = sign;
            playerTransform.localScale = scale;
        }
    }

    //Stuff to override
    protected virtual void OnSeated()
    {

    }

    protected virtual void OnUnSeated()
    {

    }

    //Fires only the first time the animal button is presssed
    protected virtual void Activated()
    {

    }

    //Fires continually while the animal is activated
    protected virtual void ContinualUse()
    {

    }

    //Fires when the button stops being pressed
    protected virtual void Deactivated()
    {

    }
    //End stuff to override

    private void Seated()
    {
        isSeated = true;
        originalScale = Mathf.Sign(playerTransform.localScale.x);
        animalController.enabled = true;
        playerController.enabled = false;
        OnSeated();
    }

    private void Unseated()
    {
        isSeated = false;
        Vector3 scale = playerTransform.localScale;
        scale.x = originalScale;
        playerTransform.localScale = scale;

        animalController.enabled = false;
        playerController.enabled = true;
        
		Vector3 playerPos = playerTransform.position;
		playerPos.y += jumpOffAddY;
		playerTransform.position = playerPos;

        OnUnSeated();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.isTrigger || isSeated) return;
        Transform root = other.transform.root.transform;
        if (root.CompareTag("Player"))
        {
            playerTransform = root;
            playerController = root.GetComponent<PlayerController1>();
            Seated();
        }
    }
}
