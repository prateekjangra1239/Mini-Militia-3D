using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCrouch : MonoBehaviour
{
	public Transform defaultPos;
	public Transform startingPos;
	public Transform crouchPos;
	
	public Joystick joystick;
	public LayerMask groundMask;
	
	void Update()
	{
		if (isGrounded())
		{
			if (joystick.Vertical < -.5f)
			{
				defaultPos.DOMove(crouchPos.position, 0.3f, false);
				GetComponent<PlayerMovement>().moveSpeed = 150;
			}
			else
			{
				defaultPos.DOMove(startingPos.position, 0.3f, false);
				GetComponent<PlayerMovement>().moveSpeed = 300;
			}
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
