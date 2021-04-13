using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    Transform mainCamera;

    [SerializeField]
    private Vector2 mouseSensitivity = new Vector2(50, 50);
    
    float yRotation = 0;
    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        gameObject.transform.Rotate(Vector3.up * mouseX);
        mainCamera.localRotation = Quaternion.Euler((yRotation), 0f, 0f);
    }
}
