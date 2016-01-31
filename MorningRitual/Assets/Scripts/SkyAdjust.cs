using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkyAdjust : MonoBehaviour {

    public float maxX = 0;

	// Use this for initialization
	void Start () {
       float scale = SceneManager.sceneCount / (float)SceneManager.GetActiveScene().buildIndex;
        Vector3 pos = transform.position;
        pos.y -= maxX * (1 - scale);
        transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
