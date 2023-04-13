using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerShooting_ArmHandler : MonoBehaviour
{
	public Joystick joystick;
	private Vector3 movement;
	public float joystickDeadZone;
	
	private bool isFacingRight = true;
	private enum FacingDirection {RIGHT, LEFT}
	private FacingDirection facingDir; 
	public float rotateSpeed;
	
	public GameObject effectorHolder;
	
	// Update
	void Update()
	{
		JoystickMovement();

		RotateArm();
		RotatePlayer(joystick);		
	}
	
	// Joystick Axis Values
	void JoystickMovement()
	{
		movement.x = joystick.Horizontal;
		movement.z = joystick.Vertical;
	}
	
	// Rotate Arm Effector
	void RotateArm()
	{
		Vector3 lookRot = new Vector3(movement.x, movement.z, 0);
		effectorHolder.transform.LookAt(effectorHolder.transform.position + lookRot);
	}
	
	// Rotate Player On Joystick Axis Change
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
	
	// bool (GROUNDED)
	//bool isGrounded()
	//{
	//	if (Physics.CheckSphere(transform.position, 0.15f, groundMask))
	//	{
	//		return true;
	//	}
	//	return false;
	//}
}
