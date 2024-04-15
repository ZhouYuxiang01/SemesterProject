using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponInWorld; // 场景中的刀模型
    public GameObject weaponOnPlayer; // 玩家手中的刀模型

    private void Start()
    {
        // 确保游戏开始时玩家手中的武器是隐藏的
        weaponOnPlayer.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 检查触发事件的对象的Tag是否为"PickupWeapon"
        if (other.gameObject.CompareTag("Player"))
        {
            // 拾取武器：隐藏场景中的武器并在玩家手中显示武器
            weaponInWorld.SetActive(false);
            weaponOnPlayer.SetActive(true);
        }
    }
}