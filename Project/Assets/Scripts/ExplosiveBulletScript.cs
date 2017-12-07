using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBulletScript : IBulletScript
{
	Bullet bullet;

	public override void Init (Bullet b)
	{
		bullet = b;
		smoke = Instantiate (b.smokePrefab, transform.position, transform.rotation) as GameObject;
	}



	public override bool CheckCollision (RaycastHit hit)
	{
		return hit.distance < transform.GetComponent<Rigidbody> ().velocity.magnitude * 2.0f * Time.deltaTime;
	}

	public override void Collision (RaycastHit hit)
	{
		Destroy (Instantiate (bullet.explosionPrefab, hit.point, transform.rotation), 1.0f);
		foreach (Collider item in Physics.OverlapSphere (hit.point, bullet.explosionRadius)) {
			Rigidbody rb = item.GetComponent<Rigidbody> ();
			if (rb != null)
				rb.AddExplosionForce (bullet.explosionForce, hit.point, bullet.explosionRadius);
			HealthManagementScript hm = item.GetComponent<HealthManagementScript> ();
			if (hm != null)
				hm.ApplyDamage (bullet.damage);
		}
		Destroy (gameObject);
	}
}
