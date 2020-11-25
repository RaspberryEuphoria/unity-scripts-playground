using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 50f;
    public float gravityScale = 0.3f;
    public CharacterController characterController;
    public Vector3 moveDirection;

    void Start()
    {
        characterController = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump")) {
            moveDirection.y = jumpForce;
        }

        moveDirection.y += Physics.gravity.y * gravityScale;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
