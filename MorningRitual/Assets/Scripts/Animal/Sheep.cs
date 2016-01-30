using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {

    public float bounceForce;
    public Animator animator;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, bounceForce));

            if (animator != null)
            {
                animator.SetTrigger("Bounce");
            }
            //GetComponent<Animation>().Play("SheepBounce");
        }
    }
}
