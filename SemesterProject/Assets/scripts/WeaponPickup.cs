using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
<<<<<<< Updated upstream
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
=======
    public GameObject weaponOnGround; // 地图上的武器
    public GameObject weaponInHand; // 主角手中的武器
    //public GameObject pickupText; // 提示文字的UI对象

    void Start()
    {
        weaponInHand.SetActive(false); // 确保游戏开始时主角手中的武器是隐藏的
        //pickupText.SetActive(false); // 确保游戏开始时拾取提示也是隐藏的
    }

    private void OnTriggerEnter(Collider other)
>>>>>>> Stashed changes
    {
        weaponInHand = weapon;
    }


    void OnTriggerStay(Collider other)
    {
        // 检查触发器内的对象是否为玩家，并且玩家是否按下了F键
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            // 隐藏地图上的武器
            weaponOnGround.SetActive(false);

            // 显示主角手中的武器
            weaponInHand.SetActive(true);
        }
    }
}
=======
            //pickupText.SetActive(false); // 进入时可以选择隐藏提示文字
            weaponOnGround.SetActive(false); // 隐藏地图上的武器   
        }
        weaponInHand.SetActive(true); // 显示主角手中的武器
    }

    private void OnTriggerExit(Collider other)
    {
        // 当玩家离开触发区域时，如果你想要有一些额外的逻辑，可以在这里添加
        weaponInHand.SetActive(true);
    }
}
>>>>>>> Stashed changes
