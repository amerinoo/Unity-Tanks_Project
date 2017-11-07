using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
	public Magazine[] magazines;
	private int selectedMagazine;

	private HudControllerScript hcs;

	// Use this for initialization
	void Start ()
	{
		selectedMagazine = 0;
		for (int i = 0; i < magazines.Length; i++) {
			magazines [i].setDefaults ();
		}

		hcs = GetComponent<HudControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hcs != null) {
			Magazine magazine = magazines [selectedMagazine];
			hcs.UpdateHUD (magazine.bullet.color, magazine.remainingBullets, magazine.maxBullets);
		}
	}

	public void Substract ()
	{
		magazines [selectedMagazine].Substract ();
	}

	public Bullet Bullet {
		get{ return magazines [selectedMagazine].bullet; }
	}

	public bool HasBullets ()
	{
		return magazines [selectedMagazine].HasBullets (); 
	}

	public void NextMagazine ()
	{
		selectedMagazine = (selectedMagazine + 1) % magazines.Length;
	}

	public void IncrementAmmo (Bullet.Kind k)
	{
		Magazine magazine = magazines [(int)k];
		int ammo = Mathf.RoundToInt (magazine.maxBullets * 0.1f);
		int newAmmo = magazine.remainingBullets + ammo;
		magazine.remainingBullets = (magazine.maxBullets < newAmmo) ? magazine.maxBullets : newAmmo;
	}
}
