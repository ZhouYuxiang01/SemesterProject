using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public Animator characterAnimator;
    public Transform cameraTransform;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        animator = GetComponent<Animator>(); // 获取动画组件
        rb = GetComponent<Rigidbody>();     // 获取刚体组件

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // 确保摄像机Transform被正确设置
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // 根据输入和是否在跑步计算移动速度和方向
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0; // 确保方向是水平的
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        float speed = isRunning ? runSpeed : walkSpeed;
        movement = (forward * vertical + right * horizontal).normalized * speed;

        // 设置动画参数
        characterAnimator.SetFloat("Speed", movement.magnitude);
        characterAnimator.SetBool("IsRunning", isRunning);
    }

    private void FixedUpdate()
    {
        if (movement.magnitude > 0)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(newRotation);
        }
    }
}
