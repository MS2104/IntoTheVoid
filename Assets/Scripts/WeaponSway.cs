using System;
using UnityEngine;

public class WeaponSwayDuplicateLmao : MonoBehaviour
{

    [Header("Sway Settings")]
    [SerializeField] private float smooth1;
    [SerializeField] private float multiplier1;

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * multiplier1;
        float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier1;

        // calculate target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        // rotate 
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth1 * Time.deltaTime);
    }
}