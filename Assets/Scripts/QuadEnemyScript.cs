using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class QuadEnemyScript : MonoBehaviour
{
	private WeaponScript[] weaponScripts;
	private Transform[] weaponTransforms;
	
	void Awake()
	{
		weaponTransforms = GetComponentsInChildren<Transform>();
		// Retrieve the weapon only once
		weaponScripts = GetComponentsInChildren<WeaponScript>();
	}
	
	void Update()
	{
		// Get new weapon Z-axis rotation positions
		// lazy way (every update)
		foreach (Transform transform in weaponTransforms) {
			transform.Rotate(0, 0, Random.Range(-180.0f, 180.0f));
		}

		foreach (WeaponScript weapon in weaponScripts)
		{
			// Auto-fire
			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack(true);
			}
		}
	}
}