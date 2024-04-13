using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIme : MonoBehaviour
{

    public float time = 30f;
    private float restTime;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        restTime = time - Time.deltaTime;
        if (restTime == 0)
        {
            //win();
        }
    }
}
