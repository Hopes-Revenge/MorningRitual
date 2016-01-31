using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour {

    public string sceneName;
    public bool useNumberSet = false;
    public int numberSetAdd = 1;

    private LoadHandler loadHandler;
    private AsyncOperation operation;

    void Awake()
    {
        loadHandler = GameObject.FindObjectOfType<LoadHandler>();
    }

	public void LoadScene()
    {
        if(loadHandler != null)
        {
            DontDestroyOnLoad(loadHandler.gameObject);
        }
        if(useNumberSet)
        {
            int index = SceneManager.GetActiveScene().buildIndex + numberSetAdd;
            operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        } else {
            operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
        if(loadHandler != null)
        {
            loadHandler.Load();
        }
    }

    void Update()
    {
        if(loadHandler != null && operation != null)
        {
            if(operation.isDone)
            {
                loadHandler.Loaded();
            }
        }
    }
}
