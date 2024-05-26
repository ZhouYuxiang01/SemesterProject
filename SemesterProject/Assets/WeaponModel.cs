using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private GameObject handweapon;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    // Start is called before the first frame update
    void Start()
    {
        handweapon = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
        }
        switch (other.gameObject.name)
        {
            case "30damage":
                weapon1.SetActive(true);
                other.gameObject.SetActive(false);
                break;
            case "60damage":
                weapon2.SetActive(true);
                other.gameObject.SetActive(false);
                break;
            case "60damage (1)":
                weapon2.SetActive(true);
                other.gameObject.SetActive(false);
                break;
            case "100damage":
                weapon3.SetActive(true);
                other.gameObject.SetActive(false);
                break;
            case "100damage (1)":
                weapon3.SetActive(true);
                other.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
