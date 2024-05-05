using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDownCamera : MonoBehaviour
{
    public Transform target; // 目标物体，角色
    public Camera cameraToUse; // 使用的相机
    public float orbitDistance = 10.0f; // 相机环绕距离
    public float orbitHeight = 5.0f; // 相机高度
    public float orbitSpeed = 45.0f; // 相机环绕速度
    public Vector3 lookAtOffset = new Vector3(0, 1, 0); // 注视偏移

    //public float speed = 5.0f; // 角色移动速度

    private float orbitAngle = 0.0f; // 环绕角度
    private CharacterController characterController; // 角色控制器组件

    void Awake()
    {
        characterController = target.GetComponent<CharacterController>(); // 获取角色的CharacterController组件

        if (cameraToUse == null)
        {
            cameraToUse = Camera.main; // 如果未在Inspector中指定，自动使用主摄像机
        }
    }


    void LateUpdate()
    {
        HandleCameraControl();
        MoveCharacter();
    }

    void HandleCameraControl()
    {
        if (target != null)
        {
            // 使用鼠标X轴移动来旋转相机
            float mouseX = Input.GetAxis("Mouse X");
            orbitAngle += mouseX * orbitSpeed * Time.deltaTime;

            Vector3 orbitDirection = Quaternion.Euler(0, orbitAngle, 0) * Vector3.back;
            Vector3 orbitPosition = target.position + orbitDirection * orbitDistance + Vector3.up * orbitHeight;

            cameraToUse.transform.position = orbitPosition;
            cameraToUse.transform.LookAt(target.position + lookAtOffset);
        }
    }

    void HideCursor()
    {
        Cursor.visible = false;
    }

    void ShowCursor()
    {
        Cursor.visible = true;
    }

    void MoveCharacter()
    {
        if (!characterController) return; // 如果没有CharacterController组件，则不执行移动逻辑

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraToUse.transform.forward;
        Vector3 right = cameraToUse.transform.right;
        forward.y = 0; // 确保移动方向为水平
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * vertical + right * horizontal).normalized;
    }
}
