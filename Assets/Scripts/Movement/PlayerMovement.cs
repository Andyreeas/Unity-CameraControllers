using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed = 10f;
    public float jumpHeight = 5f;
    bool isGrounded;

    //physics settings
    public float gravity = -9.81f;
    Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jump

        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        //physics (gravity)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = -2;
        }
        //RaycastHit(Vector3.down);
    }
}
