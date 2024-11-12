using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickRaycaster : MonoBehaviour
{
    private PlayerInputController playerInput;
    private IInteractable CurrentInteractable;
    private int maxDistance = 15;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInputController>();
    }

    private void OnEnable()
    {
        playerInput.OnClickEvent += OnClick;
    }

    private void OnDisable()
    {
        playerInput.OnClickEvent -= OnClick;
    }


    private void OnClick(bool isClick)
    {
        int layerMask = 1 << LayerNames.Tree;
        RaycastHit2D hit = Physics2D.Raycast(playerInput.MousePosition, Vector2.zero, Mathf.Infinity, layerMask);
        CurrentInteractable = hit.collider.GetComponent<IInteractable>();
        CurrentInteractable.Interact();
    }
}
