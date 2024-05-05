using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeapon : MonoBehaviour
{
    public Weapon NewWeapon;

    protected CharacterHandleWeapon _characterHandleWeapon;
    // Start is called before the first frame update
    void Start()
    {
        _characterHandleWeapon = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterHandleWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
