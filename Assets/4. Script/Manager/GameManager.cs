using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public TreeController tree;
    public Timer timer;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        tree = FindObjectOfType<TreeController>();
        timer = FindObjectOfType<Timer>();
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
    }

    public void GameStart()
    {

    }

    public void GameOver()
    {
        Debug.Log("³¡");
        //UIManager.Instance.UIGameOver.SetActive(true);
    }
}
