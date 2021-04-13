using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonCamera : MonoBehaviour
{
    public Transform playerObject;

    [SerializeField]
    private Vector2 mouseSensitivity = new Vector2(50, 50);
    
    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerObject.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler((xRotation), 0f, 0f);
    }
}
