using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 15.0f;
    public bool isJumpPressed = false;
    public float jumpForce = 2.0f;

    public float maxSpeed = 50f;
    public float maxJumpForce = 10f;
    public float maxScale = 8f;

	private Rigidbody rb;
	private Vector3 moveDirection;

	void Start () 
	{
		rb = this.GetComponent<Rigidbody> ();	
	}

    private void Update()
    {
        // Get the axis and jump input.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        isJumpPressed = Input.GetButton("Jump");

        moveDirection = (v*Vector3.forward + h*Vector3.right).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection*speed, ForceMode.Acceleration);

        //If jumping and in the ground...
        if (Physics.Raycast(transform.position, -Vector3.up, 2.0f) && isJumpPressed)
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        } else {
            isJumpPressed = false;
        }  
    }

}