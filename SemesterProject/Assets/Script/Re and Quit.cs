using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReandQuit : MonoBehaviour
{

    public Canvas gameplayCanvas; // 游戏进行中的Canvas
    public Canvas endGameCanvas; // 游戏结束时的Canvas
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重载当前场景
        Time.timeScale = 1; // 恢复正常游戏速度

        // 重置画布状态
        gameplayCanvas.gameObject.SetActive(true);
        endGameCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1; // 确保时间恢复正常
        Application.Quit(); // 退出游戏
    }
}
