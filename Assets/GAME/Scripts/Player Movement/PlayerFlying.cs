using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class PlayerFlying : MonoBehaviour
{
	public Joystick joystick;
	public Rigidbody rb;
	public float forceAmount;
	
	public FullBodyBipedIK finalIk;
	public LayerMask groundMask;
	
	void Update()
	{
		if (joystick.Vertical > 0.4f)
			rb.AddForce(transform.up * forceAmount, ForceMode.Force);
		else
			rb.AddForce(-transform.up * 0.7f);
			
			
			
		if (isGrounded () == true)
			finalIk.solver.bodyEffector.positionWeight = 1;
		else
			finalIk.solver.bodyEffector.positionWeight = 0;
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
