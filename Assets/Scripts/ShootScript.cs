using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
	public AmmoController ac;
	public GameObject shootExplosionPrefab;

	private HudControllerScript hcs;
	private Transform manWithButton;
	private Transform canon;
	private Transform bulletSpawn;
	private float time;

	// Use this for initialization
	void Start ()
	{
		time = 0.0f;
		hcs = GetComponent<HudControllerScript> ();
		manWithButton = transform.Find ("Turret/ManWithButton");
		canon = transform.Find ("Turret/CanonParent/Canon");
		bulletSpawn = canon.Find ("BulletSpawn");

	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
	}

	public void Fire ()
	{
		if (ac.HasBullets () && CanShoot ()) {
			time = 0.0f;
			AnimateMan ();
			AnimateCanon ();
			ac.Substract ();
			InstantiateBullet ();
			ShootExplosionEffect ();			  
		}
	}

	public bool CanShoot ()
	{
		return time > ac.GetTTL ();
	}

	void AnimateMan ()
	{
		if (manWithButton.parent.gameObject.activeSelf)
			manWithButton.GetComponent<Animator> ().SetTrigger ("Shoot");
	}

	void AnimateCanon ()
	{
		canon.GetComponent<Animator> ().SetTrigger ("Shoot");
	}

	void InstantiateBullet ()
	{
		Bullet bullet = ac.Bullet;
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



	public bool CheckDistance ()
	{
		if (ac.HasBullets ()) {
			Ray ray = new Ray (canon.position, canon.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				float d = ac.Bullet.Distance - hit.distance;
				bool check = hit.transform.CompareTag ("Cubes") && Mathf.Sign (d) > 0.0f;
				hcs.CheckDistance (check);
				return check;
			}
		}
		return false;
	}

	public void NextMagazine ()
	{
		time = 0.0f;
		ac.NextMagazine ();
	}
}
