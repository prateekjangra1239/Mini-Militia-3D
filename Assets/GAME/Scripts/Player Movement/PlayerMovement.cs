using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	public Animator anim;
	public Rigidbody rb;
	public LayerMask groundMask;
	
	
	private bool isFacingRight = true;
	private enum FacingDirection {RIGHT, LEFT}
	private FacingDirection facingDir; 
	public float rotateSpeed;
	
	
	public Joystick joystick;
	private Vector3 movement;
	public float moveSpeed;
	public float joystickDeadZone;
	
	// Update
	void Update()
	{
		JoystickValueHandler();
	}
	
	// Fixed Update
	void FixedUpdate()
	{	
		RotatePlayer(joystick);
		MovePlayer();
    }
    
	// Joystick Value Handler
	void JoystickValueHandler()
	{
		movement.x = joystick.Horizontal;
		movement.y = joystick.Vertical;
	}
	
	// Rotate Player (JOYSTICK)
	public void RotatePlayer(Joystick joystick)
	{
		if (joystick.Horizontal < joystickDeadZone && isFacingRight == true)
		{
			facingDir = FacingDirection.LEFT;
			isFacingRight = false;
			
			transform.DORotate(new Vector3(0, -90, 0), rotateSpeed, RotateMode.Fast);
		}
		else if (joystick.Horizontal > joystickDeadZone && isFacingRight == false)
		{
			facingDir = FacingDirection.RIGHT;
			isFacingRight = true;
			
			transform.DORotate(new Vector3(0, 90, 0), rotateSpeed, RotateMode.Fast);
		}
		else return;
	}
	
	// Move Player (JOYSTICK)
	void MovePlayer()
	{
		if (joystick.Horizontal != 0 || joystick.Vertical != 0)
		{
			rb.velocity = new Vector3(movement.x * moveSpeed * Time.deltaTime, rb.velocity.y, 0);
		}
		
		if (isGrounded())
		{
			//anim.SetBool("Fly", false);
			anim.SetFloat("Blend", Mathf.Abs(movement.x));
		}
		else
		{
			anim.SetFloat("Blend", 0);
			//anim.SetBool("Fly", true);
		}
	}
	
	
	// bool (GROUNDED)
	bool isGrounded()
	{
		if (Physics.CheckSphere(transform.position, 0.15f, groundMask))
		{
			return true;
		}
		return false;
	}
}
