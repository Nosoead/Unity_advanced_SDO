using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TreeController : MonoBehaviour, IInteractable
{
    private static readonly int HitTree = Animator.StringToHash("HitTree");

    private BoxCollider2D treeCollider;
    private Animator animator;
    private TreeEXP treeEXP;

    private void Awake()
    {
        treeCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        treeEXP = GetComponent<TreeEXP>();
    }

    public void Interact(BigInteger damage)
    {
        animator.SetTrigger("HitTree");
        treeEXP.GetTreeEXP(damage);
    }

    public void ToggleCollider(bool toggle)
    {
        treeCollider.enabled = toggle;
    }
}
