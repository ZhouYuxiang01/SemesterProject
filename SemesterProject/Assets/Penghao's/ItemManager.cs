using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.TopDownEngine;

public class ItemManager : MonoBehaviour
{
    public int healthCount = 3 ;
    public Health playerHp;
    public TextMeshProUGUI healthCountUI;
    public void SetHealthCount(int healthCount)
    {
        this.healthCount = healthCount;
    }
    public void AddHealthCount(int num)
    {
        healthCount += num;
        healthCountUI.text = "" + healthCount;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthCountUI.text = "" + healthCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            //¼ì²âÑªÆ¿ÊýÁ¿
            if (healthCount > 0)
            {
                playerHp.AddHealth(5);
                healthCount--;
                healthCountUI.text = "" + healthCount;
            }
        }
    }
}
