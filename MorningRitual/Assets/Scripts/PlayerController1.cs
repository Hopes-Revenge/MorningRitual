using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {
	private bool facingRight = true;
	public float speed = 5.0f;
	public float maxSpeed = 5f;
	public float jumpSpeed = 300f;
	private KeyCode lastHitKey;
	bool onGround = false;
	float thrownForce = 0;

    public bool isJumping = false;

	public float groundRadius = .1f;
	public LayerMask groundObject;
	private Vector2 lastVelocity;

	public Vector3 resetPosition;
	public bool resetLevel = false;
	public bool dead = false;

    private Animator animator;

	private bool isInteracting = false;
	private bool interactionKey = false;
	private bool nextToObject = false;
	private GameObject interactionObject;
	private float objectOffset = 0;


	private float playerMovement = 0;

	private float gatheredSpeed = 0f;

	public Rigidbody2D rdBody;

	// Use this for initialization
	void Start () {
		rdBody = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
        resetPosition = rdBody.position;
	}

	
	// Update is called once per frame
	void Update () {
        if(onGround)
        {
            isJumping = false;
        }
		
		if (Input.GetKeyDown (KeyCode.E)) {
			interactionKey = !interactionKey;
			if (interactionKey && nextToObject) {
				isInteracting = true;
			} else {
				isInteracting = false;
			}
		}
		if (resetLevel) {
			Reset();
		}

        if (animator != null)
        {
            animator.SetBool("IsJumping", rdBody.velocity.y > 0.2f);
        }
    }
	void FixedUpdate(){
		lastVelocity = rdBody.velocity;
        Vector2 tempV = new Vector2(rdBody.transform.position.x, rdBody.transform.position.y - 0.55f);
		onGround = Physics2D.OverlapCircle (tempV, groundRadius, groundObject);

		float move = Input.GetAxis ("Horizontal");
        if (animator != null)
        {
            animator.SetBool("IsWalking", Mathf.Abs(move) > 0.2f);
        }
        playerMovement = move;
		float speed = maxSpeed;
		if (isInteracting) {
			speed = 2.5f;
		}

        if (GetIsJumping() && onGround)
        {
            rdBody.velocity = new Vector2(rdBody.velocity.x, 0.0f);
            rdBody.AddForce(new Vector2(0, jumpSpeed));
            thrownForce = 10f;
            isInteracting = false;
            isJumping = true;
        }

        rdBody.velocity = new Vector2 ((move * speed), rdBody.velocity.y);

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

		if (isInteracting) {
			interactionObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (rdBody.velocity.x, interactionObject.GetComponent<Rigidbody2D> ().velocity.y);
			if(Vector3.Distance(interactionObject.transform.position, rdBody.position) > 1.6){
				isInteracting = false;
			}
		}
    }

    void OnDisable()
    {
        if (animator != null)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsWalking", false);
        }
    }

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

	}


	void Reset(){

	}

    public bool GetIsJumping()
    {
        return Input.GetAxis("Vertical") > 0.1f;
    }
}

