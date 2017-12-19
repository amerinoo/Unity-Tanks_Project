using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagementScript : MonoBehaviour
{
	public float health;
	public int index;
	public float maxHealth;
	public bool heal, damage, kill;
	public GameObject tombstonePref;

	public bool immune;

	private HudControllerScript hcs;
	// Use this for initialization
	void Awake ()
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
		if (heal) {
			IncrementHealth (100);
			heal = false;
		}
		if (damage) {
			ApplyDamage (100);
			damage = false;
		}
		if (kill) {
			ApplyDamage (health);
			kill = false;
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
		if (!immune)
			health -= damage;
		if (health <= 0.0f) {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ().PlayerDead (index);
			GameObject go = Instantiate (tombstonePref);
			go.transform.position = new Vector3 (transform.position.x, -2, transform.position.z);
			go.transform.SetParent (transform.parent.parent);
			go.name = "Tombstone " + transform.parent.name;
			foreach (Transform text in go.transform.GetChild(0).Find ("Texts")) {
				text.GetComponent<TextMesh> ().text = transform.parent.name;
			}
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
