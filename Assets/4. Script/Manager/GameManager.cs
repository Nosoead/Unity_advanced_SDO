using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
    }
}
