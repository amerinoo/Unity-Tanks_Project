using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollectionScript : MonoBehaviour
{
	AmmoController ac;
	HealthManagementScript hms;
	// Use this for initialization
	void Start ()
	{
		ac = GetComponent<AmmoController> ();
		hms = GetComponent<HealthManagementScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Resources")) {
			BulletResourcesControllerScript pbc = other.GetComponent<BulletResourcesControllerScript> ();
			ac.IncrementAmmo (pbc.kind);
			Destroy (other.gameObject);
		} else if (other.CompareTag ("Health")) {
			HealthControllerScript hcs = other.GetComponent<HealthControllerScript> ();
			hms.IncrementHealth (hcs.howManyHealth);
			Destroy (other.gameObject);
		}
	}
}
