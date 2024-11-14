using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OverlapPoint로 클릭한 지점에 대해 collider를 레이어 마스크로 찾아냅니다. rigidbody가 필요없을 것 같아 raycasthit2d로 접근했다가 잘못접근해서 overlappoint로 접근했습니다.
public class PlayerClickOverlapPoint : MonoBehaviour
{
    private PlayerInputController playerInput;
    private IInteractable currentInteractable;
    private PlayerTapDamage playerTapDamage;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInputController>();
        playerTapDamage = GetComponent<PlayerTapDamage>();
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
            currentInteractable.Interact(playerTapDamage.TapDamage);
            playerTapDamage.AddDamage(playerTapDamage.TapDamage);
        }
        else
        {
            return;
        }
    }
}
