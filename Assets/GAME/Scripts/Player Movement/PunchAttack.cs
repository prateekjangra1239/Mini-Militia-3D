using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchAttack : MonoBehaviour
{
	public Transform leftHandEffector;
	public Transform [] punchTransform;
	private Vector3 leftHandStartingPos;
	
	public bool punching;
	public float punchingTime = 0.2f;
	
	public Joystick shootingJoystick;
	public Transform dirTransform;
	public Transform punchPushTransform;
	public float pushTime;
	
	private Vector3 movement;
	public Transform effectorHolder;
	
	void Start()
	{
		leftHandStartingPos = leftHandEffector.localPosition;
	}
	
	void Update()
	{
		movement.x = shootingJoystick.Horizontal;
		movement.z = shootingJoystick.Vertical;
		RotateArm();
		
		if (Input.GetKeyDown(KeyCode.Space) && punching == false && shootingJoystick.Horizontal == 0 && shootingJoystick.Vertical == 0)
		{
			Punch();
		}
		else if (Input.GetKeyDown(KeyCode.Space) && punching == false && (shootingJoystick.Horizontal != 0 || shootingJoystick.Vertical != 0))
		{
			AddForce();
			Punch();
		}
	}
	
	public void StartPunchAttack()
	{
		if (punching == false && shootingJoystick.Horizontal == 0 && shootingJoystick.Vertical == 0)
		{
			Punch();
		}
		else if (punching == false && (shootingJoystick.Horizontal != 0 || shootingJoystick.Vertical != 0))
		{
			AddForce();
			Punch();
		}
	}
	
	// Rotate Arm Effector
	void RotateArm()
	{
		Vector3 lookRot = new Vector3(movement.x, movement.z, 0);
		effectorHolder.transform.LookAt(effectorHolder.transform.position + lookRot);
	}
	
	void AddForce()
	{
		transform.DOMove(punchPushTransform.position, pushTime, false); 
	}
	
	void Punch()
	{
		punching = true;
		leftHandEffector.DOMove(punchTransform[0].position, punchingTime, false).OnComplete(PunchSequence);
	}
	
	void PunchSequence()
	{
		for (int i = 1; i < punchTransform.Length; i++)
		{
			leftHandEffector.DOMove(punchTransform[i].position, punchingTime, false).OnComplete(ResetPunch);
		}
	}
	
	void ResetPunch()
	{
		leftHandEffector.DOLocalMove(leftHandStartingPos, punchingTime, false).OnComplete(FalsePunching);
		//leftHandEffector.localPosition = leftHandStartingPos;
	}
	
	void FalsePunching()
	{
		punching = false;
	}
}
