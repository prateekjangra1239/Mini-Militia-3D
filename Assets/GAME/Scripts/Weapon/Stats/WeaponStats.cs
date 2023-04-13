using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponStats : ScriptableObject
{
	public GameObject bulletPrefab;
	
	public float forceAmount;
	public float damage;
	
	public float fireRate;
}
