using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour {

    public string sceneName;
    public bool useNumberSet = false;
    public int numberSetAdd = 1;
	public void LoadScene()
    {
        if(useNumberSet)
        {
            int index = SceneManager.GetActiveScene().buildIndex + numberSetAdd;
            SceneManager.LoadScene(index, LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
