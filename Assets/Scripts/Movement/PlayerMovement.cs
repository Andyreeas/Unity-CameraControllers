using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    InputController inputController;

    public float speed = 10f;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float timeBetweenJumps;

    bool isGrounded;

    //physics settings
    public float gravity = -9.81f;
    Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputController = FindObjectOfType<InputController>();
    }

    private void OnEnable()
    {
        inputController.OnKeyboardSpaceDown += Jump;
    }

    private void OnDisable()
    {
        inputController.OnKeyboardSpaceDown -= Jump;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        velocity = transform.right * x * speed + Vector3.up * velocity.y + transform.forward * z * speed;

        //physics (gravity)
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            velocity.y = jumpForce;
        }
    }
}
