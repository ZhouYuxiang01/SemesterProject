using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReandQuit : MonoBehaviour
{
    public Canvas gameplayCanvas; // 游戏进行中的Canvas
    public Canvas endGameCanvas; // 游戏结束时的Canvas
    public AudioSource audioSource; // AudioSource组件引用
    public AudioClip buttonClikc; // 重新开始音频片段

    public void RestartGame()
    {
        // 播放重新开始音频
        PlayAudio(buttonClikc);

        // 重载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // 恢复正常游戏速度

        // 重置画布状态
        gameplayCanvas.gameObject.SetActive(true);
        endGameCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        // 播放退出音频
        PlayAudio(buttonClikc);

        // 确保时间恢复正常
        Time.timeScale = 1;
        Application.Quit(); // 退出游戏
    }

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
