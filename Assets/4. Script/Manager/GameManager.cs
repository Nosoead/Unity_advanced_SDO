using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//게임의 진행사항을 총괄하는 곳인데 미완성입니다. 다른 성장계수 능력치 적용시키고 버그해결하다보니 UIGameOver을 만드는 것을 못 했습니다.
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
        Debug.Log("끝");
        //Time.timeScale = 0f;
        //UIManager.Instance.UIGameOver.SetActive(true);
    }
}
