using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
	public Magazine[] magazines;
	public GameObject shootExplosionPrefab;

	private int selectedMagazine;
	private Transform man;
	private Transform canon;
	private Transform bulletSpawn;
	private HudControllerScript hcs;

	// Use this for initialization
	void Start ()
	{
		selectedMagazine = 0;
		foreach (Magazine magazine in magazines)
			magazine.setDefaults ();
		man = transform.Find ("Turret/ManWithButton/Man");
		canon = transform.Find ("Turret/CanonParent/Canon");
		bulletSpawn = canon.Find ("BulletSpawn");
		hcs = GetComponent<HudControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hcs != null)
			hcs.UpdateHUD (magazines [selectedMagazine].bullet.color, magazines [selectedMagazine].remainingBullets, magazines [selectedMagazine].maxBullets);
	}

	public void Fire ()
	{
		if (magazines [selectedMagazine].HasBullets) {
			AnimateMan ();
			AnimateCanon ();
			magazines [selectedMagazine].Substract ();
			InstantiateBullet ();
			ShootExplosionEffect ();			  
		}
	}

	void AnimateMan ()
	{
		if (man.parent.gameObject.activeSelf)
			man.GetComponent<Animator> ().SetTrigger ("Shoot");
	}

	void AnimateCanon ()
	{
		canon.GetComponent<Animator> ().SetTrigger ("Shoot");
	}

	void InstantiateBullet ()
	{
		Bullet bullet = magazines [selectedMagazine].bullet;
		GameObject bulletGO = Instantiate (bullet.bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		bulletGO.GetComponent<ExplosiveBulletScript> ().init (bullet);
		bulletGO.GetComponent<Transform> ().localScale *= bullet.scalarFactor;
		bulletGO.GetComponent<MeshRenderer> ().materials [0].color = bullet.color;
		bulletGO.GetComponent<Rigidbody> ().velocity = bullet.speed * bulletGO.transform.forward;
		Destroy (bulletGO, bullet.time); 
	}

	void ShootExplosionEffect ()
	{
		Destroy (Instantiate (shootExplosionPrefab, bulletSpawn.position, bulletSpawn.rotation), 1.0f);
	}

	public void NextMagazine ()
	{
		selectedMagazine = (selectedMagazine + 1) % magazines.Length;
	}

	public void CheckDistance ()
	{
		if (magazines [selectedMagazine].remainingBullets > 0) {
			Ray ray = new Ray (canon.position, canon.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				float d = magazines [selectedMagazine].bullet.Distance - hit.distance;
				hcs.CheckDistance (hit.transform.CompareTag ("Cubes") && Mathf.Sign (d) > 0.0f);
			}
		}
	}
}
