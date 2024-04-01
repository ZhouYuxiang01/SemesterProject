using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPlayermove : MonoBehaviour
{
    public Transform characterTransform; // 角色的Transform
    public Transform cameraTransform;    // 相机的Transform

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // 如果没有指定，使用主相机
        }
    }

    void Update()
    {
        // 计算摄像机在水平平面的方向
        Vector3 forward = cameraTransform.forward;
        forward.y = 0; // 不考虑相机的垂直倾斜
        forward.Normalize(); // 标准化向量

        // 计算右方向
        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        // 获取基本的移动输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 转换为基于摄像机的方向
        Vector3 desiredMoveDirection = forward * verticalInput + right * horizontalInput;

        // 应用转换，使角色面向这个新的方向
        if (desiredMoveDirection != Vector3.zero)
        {
            characterTransform.rotation = Quaternion.LookRotation(desiredMoveDirection);
        }
    }
}
