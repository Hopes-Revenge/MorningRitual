using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goat : Animal {

    public float range = 1;

    protected override void Activated()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(activatedSounds[Random.Range(0, activatedSounds.Length)]);

        float sign = Mathf.Sign(transform.localScale.x);
        Debug.Log(sign);
        Vector3 startPos = transform.position + new Vector3(1.1f, 0, 0) * sign * Mathf.Abs(transform.localScale.x);
        Vector3 direction = new Vector3(sign * range, .1f, 0);
        Debug.DrawRay(startPos, direction, Color.green, 1.0f);
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, range);
        if(hit)
        {
            if(hit.transform.CompareTag("Garbage"))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
    }
    protected override void OnSeated()
    {
        //gameObject.GetComponent<AudioSource>().PlayOneShot(seatedSounds[Random.Range(0, seatedSounds.Length)]);
    }
}
