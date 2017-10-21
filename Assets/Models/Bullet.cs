using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
	public string name = "Bullet";
	public float time = 3.0f;
	public GameObject bulletPrefab;
	public float speed = 80.0f;
	public Color color;
	public GameObject smokePrefab;
	public GameObject explosionPrefab;
	public float explosionRadius = 5.0f;
	public float explosionForce = 500.0f;
	public float scalarFactor = 1.0f;
}
