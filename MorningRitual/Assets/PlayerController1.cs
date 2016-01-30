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
	public Transform groundCheck;
	public float groundRadius = .1f;
	public LayerMask groundObject;
	private Vector2 lastVelocity;

	private GameObject lastWindmill;
	public Vector3 resetPosition;
	public bool resetLevel = false;
	public bool dead = false;


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
		resetPosition = rdBody.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && onGround) {
			rdBody.AddForce(new Vector2(0,jumpSpeed));
			thrownForce = 10f;
			isInteracting = false;
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

	}
	void FixedUpdate(){
		lastVelocity = rdBody.velocity;
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundObject);

		float move = Input.GetAxis ("Horizontal");
		playerMovement = move;
		float speed = maxSpeed;
		if (isInteracting) {
			speed = 2.5f;
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

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

	}


	void Reset(){
		rdBody.position = resetPosition;
		rdBody.velocity = new Vector2 (0, 0);
		resetLevel = false;
		dead = false;
		isInteracting = false;
	}
}

