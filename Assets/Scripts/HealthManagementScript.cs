using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagementScript : MonoBehaviour
{
	public float health;
	public int index;
	private float maxHealth;
	public bool h, d;

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
		if (h) {
			IncrementHealth (100);
			h = false;
		}
		if (d) {
			ApplyDamage (100);
			d = false;
		}

	}

	public void IncrementHealth (int howManyHealth)
	{
		health += howManyHealth;
		if (health > maxHealth)
			health = maxHealth;
		CheckFire ();
	}

	public void ApplyDamage (float damage)
	{
		health -= damage;
		if (health <= 0.0f) {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().PlayerDead (index);
			Destroy (transform.gameObject);
		}
		CheckFire ();
	}

	private void CheckFire ()
	{
		int percentaje = Mathf.RoundToInt (health * 100 / maxHealth);
		int max = transform.Find ("FireZones").childCount;
		for (int i = 0; i < max; i++) {
			transform.Find ("FireZones").GetChild (i).gameObject.SetActive (percentaje <= 100 / (max + 1) * (max - i));
		}
	}
}
