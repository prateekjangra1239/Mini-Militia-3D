using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RootMotion.FinalIK;

public class PlayerCrouch : MonoBehaviour
{
	public Transform defaultPos;
	public Transform startingPos;
	public Transform crouchPos;
	
	public Joystick joystick;
	public LayerMask groundMask;
	
	public Animator anim;
	public FullBodyBipedIK finalIk;
	
	public bool crouch = false;
	
	void Update()
	{
		if (isGrounded() && joystick.Vertical < -.5f && !crouch)
		{
			crouch = true;
			GetComponent<PlayerMovement>().moveSpeed = 150;
			SetBodyEffector_Crouch();
		}
		else if (isGrounded() && (joystick.Vertical > -.5f || joystick.Vertical == 0 || joystick.Horizontal == 0) && crouch)
		{
			crouch = false;
			GetComponent<PlayerMovement>().moveSpeed = 300;
			SetBodyEffector_Stand();
		}
	}
	
	
	void SetBodyEffector_Crouch()
	{
		defaultPos.position = crouchPos.position;
	}
	void SetBodyEffector_Stand()
	{
		defaultPos.position = startingPos.position;
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
