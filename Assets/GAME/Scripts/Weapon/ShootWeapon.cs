using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootWeapon : MonoBehaviour
{
	public Joystick joystick;
	public Transform spawnTransform;
	public GameObject gun;
	public Transform recoilTransform;
	public Transform gunTransformDefault;
	private bool isRecoiling;
	public float recoilTime;
	
	public WeaponStats gunAk47;
	private GameObject bulletPrefab;
	private float forceAmount;
	private float damage;
	private float fireRate;
	private float nextTimeToFire;
	
	public float shootJoystickDeadZone;
	
	public float strayFactor;
	
	void Start()
	{
		bulletPrefab = gunAk47.bulletPrefab;
		forceAmount = gunAk47.forceAmount;
		damage = gunAk47.damage;
		fireRate = gunAk47.fireRate;
		
	}
	
	void Update()
	{
		float moveX = Mathf.Abs(joystick.Horizontal);
		float moveY = Mathf.Abs(joystick.Vertical);
		
		if ((moveX > shootJoystickDeadZone || moveY > shootJoystickDeadZone) && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f/fireRate; 
			Shoot();
		}
	}
	
	void Shoot()
	{
		//isRecoiling = true;
		gun.transform.DOMove(recoilTransform.position, recoilTime, false).OnComplete(ResetRecoilTransform);
	}
	
	void ResetRecoilTransform()
	{
		GameObject bullet = Instantiate(bulletPrefab, spawnTransform.position, spawnTransform.rotation);
		
		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		rb.AddForce(spawnTransform.forward * forceAmount, ForceMode.Impulse);		
		
		gun.transform.DOMove(gunTransformDefault.position, recoilTime, false).OnComplete(False_Recoiling);
		
	}
	
	void False_Recoiling()
	{
		//isRecoiling = false;
	}
}
