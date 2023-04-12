using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlying : MonoBehaviour
{
	public Joystick joystick;
	public Rigidbody rb;
	public float forceAmount;
	
	void Update()
	{
		if (joystick.Vertical > 0.4f)
		{
			rb.AddForce(transform.up * forceAmount);
		}
		else
		{
			return;
		}
	}
}
