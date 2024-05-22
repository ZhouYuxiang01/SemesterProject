using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bottle : MonoBehaviour
{
    private ItemManager itemManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.Find("ItemManager");
        itemManager = tmp.GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.tag == "Player")
        {
            itemManager.AddHealthCount(1);
            Destroy(this.gameObject);
        } 
    }
}
