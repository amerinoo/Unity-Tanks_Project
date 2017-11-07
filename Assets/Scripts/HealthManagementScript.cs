using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagementScript : MonoBehaviour
{
	public float health;
	private float maxHealth;

	private HudControllerScript hcs;
	// Use this for initialization
	void Start ()
	{
		hcs = GetComponent<HudControllerScript> ();
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hcs != null) {
			hcs.UpdateHUD (health);
		}
	}

	public void IncrementHealth (int howManyHealth)
	{
		health += howManyHealth;
		if (health > maxHealth)
			health = maxHealth;
	}

	public void ApplyDamage (float damage)
	{
		health -= damage;
		if (health <= 0.0f) {
			Destroy (transform.gameObject);
		}
	}
}
