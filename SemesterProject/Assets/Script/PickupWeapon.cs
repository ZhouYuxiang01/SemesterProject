using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private CharacterHandleWeapon characterHandleWeapon;
    public Weapon newInitialWeapon;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterHandleWeapon = other.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterHandleWeapon>();
            characterHandleWeapon.ChangeWeapon(newInitialWeapon, "1", false);

        }
    }
}