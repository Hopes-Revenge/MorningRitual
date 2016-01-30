using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class LevelEndTrigger : MonoBehaviour
{
    public bool doesMakeWin = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;
        Transform root = other.transform.root.transform;
        if (root.CompareTag("Player"))
        {
            GameManager manager = GameManager.FindObjectOfType<GameManager>();
            manager.TriggerLevelEnd(doesMakeWin);
        }
    }
}
