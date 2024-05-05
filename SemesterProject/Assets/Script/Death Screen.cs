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
    public GameObject objectToMonitor; // 要监控的对象

    public GameObject victoryObject; // 在胜利时激活的GameObject
    public GameObject defeatObject; // 在失败时激活的GameObject

    private void Start()
    {
        gameUIPanel.SetActive(false);

        // 确保胜利和失败对象在开始时被禁用
        if (victoryObject != null)
            victoryObject.SetActive(false);
        if (defeatObject != null)
            defeatObject.SetActive(false);
    }

    private void Update()
    {
        if (objectToMonitor != null && !objectToMonitor.activeInHierarchy) // 检查对象是否被禁用
        {
            ShowDefeatScreen();
        }
    }

    public void ShowVictoryScreen()
    {
        Time.timeScale = 0; // 停止游戏时间
        gameUIPanel.SetActive(true); // 显示游戏结束面板
        statusText.text = "Congratulations! You Won!";

        // 激活胜利GameObject，如果它存在
        if (victoryObject != null)
            victoryObject.SetActive(true);
        // 确保失败对象被禁用
        if (defeatObject != null)
            defeatObject.SetActive(false);
    }

    public void ShowDefeatScreen()
    {
        Time.timeScale = 0; // 停止游戏时间
        gameUIPanel.SetActive(true); // 显示游戏结束面板
        statusText.text = "Game Over! You Died!";

        // 激活失败GameObject，如果它存在
        if (defeatObject != null)
            defeatObject.SetActive(true);
        // 确保胜利对象被禁用
        if (victoryObject != null)
            victoryObject.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // 恢复正常游戏速度
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重载当前场景
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // 确保时间恢复正常
        Application.Quit(); // 退出游戏
    }
}
