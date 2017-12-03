using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Magazine
{
	public Bullet bullet;
	public int maxBullets;
	public float ttl;
	[HideInInspector]
	public int remainingBullets;

	public void setDefaults ()
	{
		remainingBullets = maxBullets;
	}

	public float TTL ()
	{
		return ttl;
	}

	public bool HasBullets ()
	{
		return remainingBullets > 0; 
	}

	public void Substract ()
	{
		remainingBullets--;
	}
}
