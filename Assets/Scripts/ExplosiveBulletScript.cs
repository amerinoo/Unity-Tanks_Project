using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBulletScript : MonoBehaviour
{
	[SerializeField]
	public GameObject smokePrefab;
	[SerializeField]
	public GameObject explosionPrefab;

	bool hasHit = false;
	GameObject smoke;
	float exposionRadious = 5.0f;

	void Start ()
	{
		smoke = Instantiate (smokePrefab, transform.position, transform.rotation) as GameObject;

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
					Debug.Log ("Hit");
					hasHit = true;
					Instantiate (explosionPrefab, hit.point, transform.rotation);
					foreach (Collider item in Physics.OverlapSphere (hit.point, exposionRadious)) {
						Rigidbody rb = item.GetComponent<Rigidbody> ();
						if (rb != null)
							rb.AddExplosionForce (500.0f, hit.point, exposionRadious);
					}
					Destroy (gameObject, 0.3f);
				}
			}
		}

	}

	void OnDestroy ()
	{
		smoke.GetComponent<DestroySmokeScript> ().Destroy ();
	}
}
