using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject gameUIPanel; // 游戏结束UI面板
    public TMP_Text statusText; // 显示胜利或死亡消息的文本

    void Start()
    {
        gameUIPanel.SetActive(false); // 初始时隐藏游戏结束面板
    }

    public void EndGame(bool playerWon)
    {
        Time.timeScale = 0; // 停止游戏时间
        gameUIPanel.SetActive(true); // 显示游戏结束面板
        statusText.text = playerWon ? "Congratulations! You Won!" : "Game Over! You Died!";
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // 恢复正常游戏速度
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重载当前场景
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // 确保时间恢复正常，如果你的退出操作是加载另一个场景
        Application.Quit(); // 退出游戏
    }
}
