using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
    public Transform target;
    public float orbitDistance = 10.0f;
    public float orbitHeight = 5.0f;
    public float orbitSpeed = 90.0f;
    public Vector3 lookAtOffset = new Vector3(0, 1, 0); 

    private float orbitAngle = 0.0f; 

    void LateUpdate()
    {
        if (target != null)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                orbitAngle -= orbitSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                orbitAngle += orbitSpeed * Time.deltaTime;
            }

            Vector3 orbitDirection = Quaternion.Euler(0, orbitAngle, 0) * Vector3.back;
            Vector3 orbitPosition = target.position + orbitDirection * orbitDistance + Vector3.up * orbitHeight;
            transform.position = orbitPosition;

            transform.LookAt(target.position + lookAtOffset);
        }
    }
}
