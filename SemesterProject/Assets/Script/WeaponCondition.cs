using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    public Text pickupText; // 拾取提示的UI Text组件
    public float detectionRange = 3f; // 检测范围
    public LayerMask interactableLayer; // 可互动物品所在的Layer

    void Update()
    {
        RaycastHit hit;

        // 从玩家的视角发出一条射线
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // 检测射线是否碰撞到Layer为interactableLayer的物体
        if (Physics.Raycast(ray, out hit, detectionRange, interactableLayer))
        {
            if (hit.collider.CompareTag("Weapon")) // 确保碰撞的物体标签为"Weapon"
            {
                pickupText.gameObject.SetActive(true); // 显示拾取提示
            }
            else
            {
                pickupText.gameObject.SetActive(false); // 隐藏拾取提示
            }
        }
        else
        {
            pickupText.gameObject.SetActive(false); // 如果没有检测到物品，隐藏拾取提示
        }
    }
}