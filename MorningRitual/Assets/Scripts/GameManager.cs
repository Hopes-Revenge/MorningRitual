using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [Header("Setup")]
    public Canvas canvas;
    public UIAnimateState levelWinScreen;
    public UIAnimateState levelRepeatScreen;
    public UIAnimateState levelPauseScreen;
    public GameObject[] instatiate;
    public bool foundEgg = false;

    [Header("Camera Bounds")]
    public Vector2 min;
    public Vector2 max;

    private Transform foundEggPanel;
    private Transform notFoundEggPanel;
    private Text timeText;
    private bool hasTriggeredEnd = false;
    private float levelTime = 0;

    void Awake()
    {
        for(int i = 0; i < instatiate.Length; i++)
        {
            Instantiate(instatiate[i]);
        }

        canvas = Instantiate(canvas) as Canvas;
        levelWinScreen = Instantiate(levelWinScreen) as UIAnimateState;
        Transform midPanel = levelWinScreen.transform.FindChild("MidPanel");
        if(midPanel)
        {
            timeText = midPanel.GetComponentInChildren<Text>();

            Transform eggPanel = midPanel.FindChild("GoldenEggPanel");
            if(eggPanel)
            {
                foundEggPanel = eggPanel.FindChild("FoundPanel");
                notFoundEggPanel = eggPanel.FindChild("NotFoundPanel");
            }
        }

        levelRepeatScreen = Instantiate(levelRepeatScreen) as UIAnimateState;
        levelPauseScreen = Instantiate(levelPauseScreen) as UIAnimateState;

        levelWinScreen.transform.SetParent(canvas.transform, false);
        levelRepeatScreen.transform.SetParent(canvas.transform, false);
        levelPauseScreen.transform.SetParent(canvas.transform, false);
    }

    void Update()
    {
        levelTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelPauseScreen.IsVisible = true;
        }
    }

    public void TriggerLevelEnd(bool didWin)
    {
        if (hasTriggeredEnd) return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            PlayerController1 controller = player.GetComponent<PlayerController1>();
            Rigidbody2D body = player.GetComponent<Rigidbody2D>();
            if(controller != null)
            {
                controller.enabled = false;
            }
            if(body != null)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }
        }

        hasTriggeredEnd = true;
        if(didWin)
        {
            if(levelWinScreen != null)
            {
                if (foundEgg)
                {
                    PlayerPrefs.SetInt("Egg " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex, 1);
                }
                PlayerPrefs.SetInt("Highest Level", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.Save();
                levelWinScreen.IsVisible = true;
                if(foundEggPanel != null)
                {
                    foundEggPanel.gameObject.SetActive(foundEgg);
                }
                if (notFoundEggPanel != null)
                {
                    notFoundEggPanel.gameObject.SetActive(!foundEgg);
                }
            } else {
                Debug.Log("HEY! Attach a level win screen please.");
            }
        } else {
            if (levelRepeatScreen != null)
            {
                levelRepeatScreen.IsVisible = true;
            }
            else
            {
                Debug.Log("HEY! Attach a level repeate screen please.");
            }
        }
        if(timeText != null)
        {
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, (int)levelTime, (int)(levelTime * 100 - ((int)levelTime)));
            timeText.text += duration.ToString().Substring(3, 8);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(min, Vector3.one * 0.2f);
        Gizmos.DrawCube(max, Vector3.one * 0.2f);
        Gizmos.DrawWireCube((max - min) / 2 + min, max - min);
    }
}
