using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTrigger : MonoBehaviour
{
    public float countdownTime = 30f;
    private float timer; // 计时器
    private bool isCountingDown = false;
    public Canvas deathScreenCanvas; // 引用 Canvas
    private DeathScreen deathScreen;
    public TextMeshProUGUI timerText;
    public GameObject targetObject; // 特定的 GameObject

    void Start()
    {
        deathScreen = deathScreenCanvas.GetComponentInChildren<DeathScreen>();
        if (deathScreen == null)
        {
            Debug.LogError("DeathScreen component not found on the canvas!");
        }
        timer = countdownTime; // 初始化计时器为倒计时时间
        timerText.enabled = false; // 开始时不显示计时器
    }

    void Update()
    {
        if (isCountingDown)
        {
            timer -= Time.deltaTime; // 计时器递减
            if (timer <= 0)
            {
                timer = 0; // 防止计时器出现负值
                deathScreen.ShowVictoryScreen();
                isCountingDown = false; // 停止计时
            }
            timerText.text = Mathf.Ceil(timer).ToString(); // 更新显示的时间为整数秒
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isCountingDown = false;
            timerText.text = "Clear area";
            timerText.color = Color.red;
        }
        else if (other.gameObject == targetObject)
        {
            timerText.color = Color.white;
            isCountingDown = true;
            timerText.enabled = true; // 当特定 GameObject 进入触发区域，显示计时器
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            isCountingDown = false;
            timerText.enabled = false; // 当特定 GameObject 离开触发区域，隐藏计时器
            timer = countdownTime; // 重置计时器
        }
    }
}
