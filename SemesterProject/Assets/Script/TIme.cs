using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTrigger : MonoBehaviour
{
    public float countdownTime = 30f; 
    private float timer; 
    private bool isCountingDown = false; 
    public DeathScreen DeathScreen;
    public Text timerText;
    void Update()
    {
        if (isCountingDown)
        {
            timer += Time.deltaTime; 
            if (timer >= countdownTime)
            {
                
                DeathScreen.EndGame(true); 
            }
        }else {
            timer -= Time.time;
            if (timer < 0)
            {
                timer = 0;
            }
        }
        timerText.text = Mathf.Floor(timer).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家进入触发区域，开始计时
            isCountingDown = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家离开触发区域，停止并重置计时
            isCountingDown = false;
        }
    }
}
