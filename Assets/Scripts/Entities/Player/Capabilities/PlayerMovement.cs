using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    private Rigidbody2D rb;
    private Player _playerscr;

    [SerializeField] public float movementSpeed = 40f;

    float horizontalMove = 0f;

    bool isJumping = false;

    private void OnEnable()
    {
        Player.onPlayerDeath += FreezeMovement;
    }

    private void OnDisable()
    {
        Player.onPlayerDeath -= FreezeMovement;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerscr = GetComponent<Player>();
    }

    private void Start()
    {
        Player.onPlayerDeath += FreezeMovement;
    }

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

    public void IncreaseMoveSpeed(float additionalMoveSpeed)
    {
        movementSpeed += additionalMoveSpeed;
    }

    public void FreezeMovement()
    {
        if (rb != null) rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
