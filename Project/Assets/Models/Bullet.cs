using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
	public enum Kind
	{
		Inpulse,
		High_Explosive,
		Armor_piercing
	}

	public string name;
	public Kind kind;
	public float time;
	public float speed;
	public float damage;
	public Color color;
	public GameObject bulletPrefab;
	public GameObject smokePrefab;
	public float scalarFactor;

	public GameObject explosionPrefab;
	public float explosionRadius;
	public float explosionForce;

	public float inpulseForce;


	public float Distance {
		get { return speed * time; }
	}
}
