using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen; // 死亡屏幕的Panel
    public Button restartButton; // 重新开始游戏的按钮
    public Button quitButton; // 退出游戏的按钮

    void Start()
    {
        deathScreen.SetActive(false); // 初始时隐藏死亡屏幕
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void PlayerDied()
    {
        deathScreen.SetActive(true); // 显示死亡屏幕
        Time.timeScale = 0; // 停止游戏时间，禁止所有游戏内移动和操作
    }

    void RestartGame()
    {
        Time.timeScale = 1; // 恢复正常游戏速度
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重载当前场景
    }

    void QuitGame()
    {
        Time.timeScale = 1; // 确保时间恢复正常，如果你的退出操作是加载另一个场景
        Application.Quit(); // 退出游戏
    }
}
