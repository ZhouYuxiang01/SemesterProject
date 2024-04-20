using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralUnit : MonoBehaviour
{
    public GameObject mainCharacter; 
    public float speed = 5.0f; 
    public float attackRange = 10.0f; 

    
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacter"); 
    }

    
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, speed * Time.deltaTime);

        
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) <= attackRange)
        {
            Attack(enemy);
        }
    }

    
    void Attack(GameObject enemy)
    {
        // Implement the attack logic here
    }
}
