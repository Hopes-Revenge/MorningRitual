using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UIAnimateState : MonoBehaviour
{
    public bool startVisbile = true;
    private Animator animator;

    private bool isVisible = false;

    // Use this for initialization
    void Awake()
    {
        isVisible = startVisbile;
        animator = GetComponent<Animator>();
        if(animator != null)
        {
            animator.speed = float.MaxValue;
            animator.SetBool("IsVisible", isVisible);
        }
    }

    void UpdateVisibility()
    {
        if (animator == null) return;
        animator.speed = 1;
        animator.SetBool("IsVisible", isVisible);
    }

    public bool IsVisible
    {
        get { return isVisible; }
        set { isVisible = value; UpdateVisibility(); }
    }
}
