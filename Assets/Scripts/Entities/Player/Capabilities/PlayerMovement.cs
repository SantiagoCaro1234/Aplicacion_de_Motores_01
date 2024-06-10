using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;

    [SerializeField] private float movementSpeed = 40f;

    float horizontalMove = 0f;

    bool isJumping = false;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}
