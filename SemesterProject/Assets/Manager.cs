using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject tipsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            tipsPanel.SetActive(!tipsPanel.active);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Òþ²ØÌáÊ¾°å
            tipsPanel.SetActive(false);
        }
    }

}
