using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerController1))]
public class Llama : Animal
{

    [Header("Setup")]
    public Transform neckTransform;

    [Header("Head")]
    public GameObject head;
    public float min;
    public float max;
    public float headSpeed;

    private BoxCollider2D box;

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();

        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
		if(!isSeated)
        {
            //Reset the neck!
            if (head.transform.localPosition.y > min)
            {
                //move the sprite down
                float currY = head.transform.localPosition.y;
                float newY = currY - headSpeed * Time.deltaTime;
                head.transform.localPosition = new Vector3(head.transform.localPosition.x, newY, head.transform.localPosition.z);

                //move the seat down
                currY = seatTransform.transform.localPosition.y;
                newY = currY - headSpeed * Time.deltaTime;

                seatTransform.transform.localPosition = new Vector3(seatTransform.transform.localPosition.x, newY, seatTransform.transform.localPosition.z);
            }

        }
        if (neckTransform != null)
        {
            Vector3 pos = neckTransform.localPosition;
            Vector3 headPos = head.transform.localPosition;
            Vector3 scale = neckTransform.localScale;
            scale.y = (headPos.y - pos.y) * 2 - 0.4f;
            neckTransform.localScale = scale;
        }
    }


    //Fires continually while the animal is activated
    protected override void ContinualUse()
    {
        //if it is less than two move it!
        if (head.transform.localPosition.y < max)
        {
            //move the sprite
            float currY = head.transform.localPosition.y;
            float newY = currY + headSpeed * Time.deltaTime;
            head.transform.localPosition = new Vector3(head.transform.localPosition.x, newY, head.transform.localPosition.z);

            //move the seat
            currY = seatTransform.transform.localPosition.y;
            newY = currY + headSpeed * Time.deltaTime;

            seatTransform.transform.localPosition = new Vector3(seatTransform.transform.localPosition.x, newY, seatTransform.transform.localPosition.z);
        }
    }

    protected override void OnSeated()
    {
        if (gameObject.GetComponent<AudioSource>().isPlaying) gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(seatedSounds[Random.Range(0, seatedSounds.Length)]);
    }
    protected override void Activated()
    {
        if(gameObject.GetComponent<AudioSource>().isPlaying)gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().PlayOneShot(activatedSounds[Random.Range(0, activatedSounds.Length)]);
    }

}
