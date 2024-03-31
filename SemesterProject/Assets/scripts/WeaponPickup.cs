using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private GameObject weaponOnGround; // 地图上的武器
    private GameObject weaponInHand; // 主角手中的武器

    void Start()
    {
        weaponInHand.SetActive(false);
        weaponOnGround = GameObject.FindWithTag("Interactable");
        weaponInHand = GameObject.FindWithTag("Weapon");
    }
    public void SetWeaponOnGround(GameObject Interactable)
    {
        weaponOnGround = Interactable;
    }

    public void SetWeaponInHand(GameObject weapon)
    {
        weaponInHand = weapon;
    }


    void OnTriggerStay(Collider other)
    {
        // 检查触发器内的对象是否为玩家，并且玩家是否按下了F键
        if (other.CompareTag("Player"))
        {
            // 隐藏地图上的武器
            weaponOnGround.SetActive(false);

            // 显示主角手中的武器
            weaponInHand.SetActive(true);
        }
    }
}
