using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public GameObject itemToCheck; 
    public TextMeshProUGUI pickupText; 
    public float displayTime = 3.0f;

    private bool wasItemActive = false; // 记录物体上一次的激活状态

    void Update()
    {
        if (itemToCheck.activeInHierarchy != wasItemActive)
        {
            if (itemToCheck.activeInHierarchy) // 如果物体被隐藏了
            {
                StartCoroutine(ShowPickupMessage("Weapon has been pick up", displayTime));
            }
            wasItemActive = itemToCheck.activeInHierarchy; // 更新物体的激活状态记录
        }
    }

    IEnumerator ShowPickupMessage(string message, float delay)
    {
        pickupText.text = message; // 设置文本内容
        pickupText.gameObject.SetActive(true); // 显示文本
        yield return new WaitForSeconds(delay); // 等待指定时间
        pickupText.gameObject.SetActive(false); // 隐藏文本
    }
}
