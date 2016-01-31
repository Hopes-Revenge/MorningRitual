using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerateLevels : MonoBehaviour {
    public GameObject SelectButtonPrefab;

	// Use this for initialization
	void Start () {
        
        if(PlayerPrefs.GetInt("Highest Level") < 1 || PlayerPrefs.GetInt("Highest Level") > UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("Highest Level", 1);
        }

        for (int i = 1; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
        {
            GameObject sceneButton = Instantiate(SelectButtonPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
            sceneButton.transform.SetParent(gameObject.transform, false);

            if (i <= PlayerPrefs.GetInt("Highest Level"))
            {
                sceneButton.GetComponentInChildren<Text>().text = "Level " + i;
                sceneButton.GetComponent<PlayScene>().numberSetAdd = i;
            }
            else
            {
                sceneButton.GetComponent<Button>().interactable = false;
            }
            
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
