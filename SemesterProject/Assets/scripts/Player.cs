using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allin : MonoBehaviour
{
    public int maxHealth = 100;
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public Animator animator;
    public Transform cameraTransform;

    private int currentHealth;
    private Rigidbody rb;
    private Vector3 movement;
    private bool isRunning;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        HandleMovementInput();
        HandleActionInput();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0; // 保持移动在水平平面上
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        movement = (forward * vertical + right * horizontal).normalized;
    }

    private void HandleActionInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Move()
    {
        float speed = isRunning ? runSpeed : walkSpeed;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(newRotation);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Speed", movement.magnitude * (isRunning ? runSpeed : walkSpeed));
        animator.SetBool("IsRunning", isRunning);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        Debug.Log("Player died.");
        // 此处可以添加角色死亡后的逻辑，比如禁用控制等
    }
}
