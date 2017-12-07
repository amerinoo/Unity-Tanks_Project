using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InpulsedBulletScript : IBulletScript
{
	Bullet bullet;


	public override void Init (Bullet b)
	{
		bullet = b;
		smoke = Instantiate (b.smokePrefab, transform.position, transform.rotation) as GameObject;
	}



	public override bool CheckCollision (RaycastHit hit)
	{
		return hit.distance < transform.GetComponent<Rigidbody> ().velocity.magnitude * Time.deltaTime;
	}

	public override void Collision (RaycastHit hit)
	{
		Rigidbody rb = hit.rigidbody;
		if (rb != null)
			rb.AddForceAtPosition (bullet.inpulseForce * transform.forward, hit.point, ForceMode.Impulse);
		HealthManagementScript hm = hit.transform.GetComponent<HealthManagementScript> ();
		if (hm != null)
			hm.ApplyDamage (bullet.damage);
		
		Destroy (gameObject);
	}
}
