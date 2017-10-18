using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmokeScript : MonoBehaviour
{
	bool hasToBeDestroyed = false;
	ParticleSystem ps;

	// Use this for initialization
	void Start ()
	{
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hasToBeDestroyed) {
			Debug.Log ("Destroy");
			Destroy (gameObject);
		} 
	}

	public void Destroy ()
	{
		hasToBeDestroyed = true;
	}
}
