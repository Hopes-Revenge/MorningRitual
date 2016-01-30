using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    //Height and width of the cube
    public float width = 1.0f;
    public float height = 1.0f;
    public Sprite[] grassSprites;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
       
    //for debugging
    void OnDrawGizmos()
    {
        //comment #1
        Vector3 pos = Camera.current.transform.position;

        //y for loop
        for (float y = pos.y- 100.0f; y < pos.y + 100.0f; y += height)
        {
            //Draw the Y grid
            Gizmos.DrawLine(new Vector3(-1000000.0f, Mathf.Floor(y / height) * height, 0.0f),
                            new Vector3(1000000.0f, Mathf.Floor(y / height) * height, 0.0f));
        }

        //x for loop
        for (float x = pos.x - 100.0f; x < pos.y + 100.0f; x += width)
        {
            //Draw the X grid
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x / width) * width, -1000000.0f, 0.0f),
                            new Vector3(Mathf.Floor(x / width) * width, 1000000.0f, 0.0f));
        }
    }

}
