using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponOnGround; // 地图上的武器
    public GameObject weaponInHand; // 主角手中的武器
    public GameObject pickupText; // 提示文字的UI对象

    void Start()
    {
        weaponInHand.SetActive(false); // 确保游戏开始时主角手中的武器是隐藏的
        pickupText.SetActive(false); // 确保游戏开始时拾取提示也是隐藏的
    }

    // 当玩家进入触发区域时显示提示
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupText.SetActive(true);
        }
    }

    // 当玩家离开触发区域时隐藏提示
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupText.SetActive(false);
        }
    }

    // 当玩家在触发区域内按下F键拾取武器时执行的逻辑
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.L))
        {
            weaponOnGround.SetActive(false); // 隐藏地图上的武器
            weaponInHand.SetActive(true); // 显示主角手中的武器
            pickupText.SetActive(false); // 拾取后隐藏提示文字
        }
    }
}