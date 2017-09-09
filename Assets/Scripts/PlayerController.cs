using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject target;
    public float speed = 8.0f;
    public float gravity = 20.0f;
    public float jumpValue = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    public int jumpCount = 0;
    public bool djump = true;

    void Update ()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            djump = true;
            jumpCount = 0;
        }

        if (jumpCount > 1)
        {
            djump = false;
        }

        if (djump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount += 1;
                moveDirection.y = jumpValue;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        //transform.LookAt(target.transform.position);
	}
}
