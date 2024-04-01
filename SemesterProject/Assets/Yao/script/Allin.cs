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
        
        if (Input.GetMouseButtonDown(0))
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
           IsHit(); 

        if (currentHealth <= 0)
        {
            Die(); 
        }

    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void IsHit()
    {
        animator.SetTrigger("IsHit");
        
    }


    private void Die()
    {
        animator.SetBool("Isdead",true); // 触发死亡动画
        //Debug.Log("Player died.");

        // 这里可以添加死亡相关的逻辑
        // 例如，禁用玩家移动和其他输入
        this.enabled = false; // 禁用此脚本以阻止进一步的控制（可选）
                              // 如果有PlayerMovementControl脚本也可以在这里禁用它
        var movement = GetComponent<PlayerMovementControl>();
        if (movement != null)
        {
            movement.enabled = false; // 假设有一个名为PlayerMovementControl的脚本控制玩家移动
        }
    }
}
