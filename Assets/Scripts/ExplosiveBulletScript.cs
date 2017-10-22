using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBulletScript : MonoBehaviour
{
	Bullet bullet;
	bool hasHit = false;
	GameObject smoke;

	public void init (Bullet b)
	{
		bullet = b;
		smoke = Instantiate (b.smokePrefab, transform.position, transform.rotation) as GameObject;
	}

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
				if (hit.distance < transform.GetComponent<Rigidbody> ().velocity.magnitude * 2.0f * Time.deltaTime) {
					hasHit = true;
					Destroy (Instantiate (bullet.explosionPrefab, hit.point, transform.rotation), 1.0f);
					foreach (Collider item in Physics.OverlapSphere (hit.point, bullet.explosionRadius)) {
						Rigidbody rb = item.GetComponent<Rigidbody> ();
						if (rb != null)
							rb.AddExplosionForce (bullet.explosionForce, hit.point, bullet.explosionRadius);
					}
					Destroy (gameObject, 0.3f);
				}
			}
		}
	}
}
