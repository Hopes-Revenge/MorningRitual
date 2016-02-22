using UnityEngine;
using System.Collections;

public class LoadScreenInserter : MonoBehaviour {

    public LoadHandler loadScreen;

	// Use this for initialization
	void Start () {
        LoadHandler loadScreenInScene = GameObject.FindObjectOfType<LoadHandler>();
        if(loadScreenInScene == null && loadScreen != null)
        {
            Instantiate(loadScreen);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
