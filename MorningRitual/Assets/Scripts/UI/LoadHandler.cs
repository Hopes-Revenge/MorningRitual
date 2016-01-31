using UnityEngine;
using System.Collections;

public class LoadHandler : MonoBehaviour {

    public Animator animator;
    public Canvas canvas;
    public Transform loadRoator;

    public float minLoadTime = 1.0f;

    private bool hasLoaded = false;
    private bool isLoaded = false;

    private float loadTimer = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(hasLoaded || isLoaded)
        {
            if(loadRoator != null)
            {
                loadRoator.Rotate(0, 0, -246.0f * Time.deltaTime);
            }
            loadTimer += Time.deltaTime;
            if(loadTimer >= minLoadTime)
            {
                isLoaded = false;
                hasLoaded = false;
                if (animator == null) return;
                animator.SetTrigger("Loaded");
                if(canvas != null)
                {
                    canvas.sortingOrder = -1;
                }
                loadTimer = 0;
            }
        }
	}

    public void Load()
    {
        if (hasLoaded) return;
        transform.SetAsFirstSibling();
        hasLoaded = true;
        isLoaded = false;
        loadTimer = 0;
        if (animator == null) return;
        animator.gameObject.SetActive(true);
        if (canvas != null)
        {
            canvas.sortingOrder = 10;
        }
        animator.SetTrigger("Load");
    }

    public void Loaded()
    {
        if (!hasLoaded) return;
        hasLoaded = false;
        isLoaded = true;
    }
}
