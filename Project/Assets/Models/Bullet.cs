using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
	public enum Kind
	{
		Bullet1,
		Bullet2,
		Bullet3
	}

	public string name = "Bullet";
	public float time = 3.0f;
	public float speed = 80.0f;
	public float damage;
	public Color color;
	public GameObject bulletPrefab;
	public GameObject smokePrefab;
	public GameObject explosionPrefab;
	public float explosionRadius = 5.0f;
	public float explosionForce = 500.0f;
	public float scalarFactor = 1.0f;
	public Kind kind;

	public float Distance {
		get { return speed * time; }
	}
}
