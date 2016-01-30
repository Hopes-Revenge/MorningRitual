using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [Header("Setup")]
    public UIAnimateState levelWinScreen;
    public UIAnimateState levelRepeatScreen;
    public Text timeText;

    private bool hasTriggeredEnd = false;
    private float levelTime = 0;

    void Update()
    {
        levelTime += Time.deltaTime;
    }

    public void TriggerLevelEnd(bool didWin)
    {
        if (hasTriggeredEnd) return;
        hasTriggeredEnd = true;
        if(didWin)
        {
            if(levelWinScreen != null)
            {
                levelWinScreen.IsVisible = true;
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
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, (int)levelTime);
            timeText.text += duration.ToString().Substring(3);
        }
    }
}
