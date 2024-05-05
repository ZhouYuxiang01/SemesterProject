using MoreMountains.TopDownEngine;
using UnityEngine;

public class ChangeInitialWeapon : MonoBehaviour
{
    public CharacterHandleWeapon characterHandleWeapon;
    public Weapon newInitialWeapon;

    void Start()
    {
        // Ensure that the characterHandleWeapon reference is set
        if (characterHandleWeapon == null)
        {
            characterHandleWeapon = GetComponent<CharacterHandleWeapon>();
        }

        // Ensure that the newInitialWeapon reference is set
        if (newInitialWeapon == null)
        {
            Debug.LogWarning("New initial weapon not set.");
        }
    }

    public void ChangeWeapon()
    {
        if (characterHandleWeapon != null && newInitialWeapon != null)
        {
            characterHandleWeapon.ChangeWeapon(newInitialWeapon, newInitialWeapon.WeaponID);
        }
    }
}
