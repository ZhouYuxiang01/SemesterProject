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

    public Canvas gameplayCanvas; // 游戏进行中的Canvas
    public Canvas endGameCanvas; // 游戏结束时的Canvas

    public GameObject victoryObject; // 在胜利时激活的GameObject
    public GameObject defeatObject; // 在失败时激活的GameObject

    public AudioSource audioSource; // 用于播放音频的AudioSource组件
    public AudioClip victoryClip; // 胜利音频片段
    public AudioClip defeatClip; // 失败音频片段

    private void Start()
    {
        gameUIPanel.SetActive(false);
        endGameCanvas.gameObject.SetActive(false); // 确保游戏结束画布一开始是禁用的
        gameplayCanvas.gameObject.SetActive(true); // 确保游戏内画布一开始是启用的

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

        // 播放胜利音频
        PlayAudio(victoryClip);

        // 激活胜利GameObject，如果它存在
        if (victoryObject != null)
            victoryObject.SetActive(true);
        // 确保失败对象被禁用
        if (defeatObject != null)
            defeatObject.SetActive(false);

        // 切换画布状态
        gameplayCanvas.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(true);
    }

    public void ShowDefeatScreen()
    {
        Time.timeScale = 0; // 停止游戏时间
        gameUIPanel.SetActive(true); // 显示游戏结束面板
        statusText.text = "Game Over! You Died!";

        // 播放失败音频
        PlayAudio(defeatClip);

        // 激活失败GameObject，如果它存在
        if (defeatObject != null)
            defeatObject.SetActive(true);
        // 确保胜利对象被禁用
        if (victoryObject != null)
            victoryObject.SetActive(false);

        // 切换画布状态
        gameplayCanvas.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(true);
    }

    private void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.Stop(); // 停止当前播放的音频
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
