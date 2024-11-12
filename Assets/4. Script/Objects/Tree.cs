using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    private static readonly int HitTree = Animator.StringToHash("HitTree");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        animator.SetTrigger("HitTree");
    }
}
