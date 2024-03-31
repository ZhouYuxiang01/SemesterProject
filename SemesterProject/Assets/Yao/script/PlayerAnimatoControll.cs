using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatoControll : MonoBehaviour
{
    public Animator animator;
    private PlayerMovementControl PlayerMovementControl;
    private PlayerController PlayerController;

    private void Start()
    {
        PlayerMovementControl = GetComponent<PlayerMovementControl>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }

        animator.SetFloat("Speed", PlayerMovementControl.CurrentSpeed());
        animator.SetBool("IsRunning", PlayerMovementControl.IsRunning());
    }
}
