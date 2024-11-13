using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickRaycaster : MonoBehaviour
{
    private PlayerInputController playerInput;
    private IInteractable currentInteractable;

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
        Collider2D collider = Physics2D.OverlapPoint(playerInput.MousePosition, layerMask);
        if (collider == null) { return; }

        currentInteractable = collider.GetComponent<IInteractable>();

        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        else
        {
            return;
        }
    }
}
