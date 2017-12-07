using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBulletScript:MonoBehaviour
{
	protected GameObject smoke;
	bool hasHit = false;

	void Start ()
	{


	}

	// Update is called once per frame
	void Update ()
	{	
		if (!hasHit) {
			smoke.transform.position = transform.position;
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (CheckCollision (hit)) {
					hasHit = true;
					Collision (hit);
				}
			}
		}
	}

	public abstract void  Init (Bullet b);

	public abstract bool CheckCollision (RaycastHit hit);

	public abstract void Collision (RaycastHit hit);
}
