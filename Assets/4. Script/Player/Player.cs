using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputController Controller { get; private set; }
    public PlayerScore Score {  get; private set; }

    private void Awake()
    {
        Controller = GetComponent<PlayerInputController>();
        Score = GetComponent<PlayerScore>();
    }
}
