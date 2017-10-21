using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
	public Transform bulletSpawn;
	public Magazine[] magazines;
	public int selectedMagazine;
	public GameObject shootExplosionPrefab;

	public Image background;
	public Text bulletsText;

	// Use this for initialization
	void Start ()
	{
		selectedMagazine = 0;
		foreach (Magazine magazine in magazines)
			magazine.setDefaults ();
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Color c = magazines [selectedMagazine].bullet.color;
		background.color = magazines [selectedMagazine].bullet.color;
		bulletsText.color = (new Vector3 (c.g, c.r, c.b).magnitude > 1.0f) ? Color.black : Color.white;
		bulletsText.text = string.Format ("{0} / {1}", magazines [selectedMagazine].remainingBullets, magazines [selectedMagazine].maxBullets);
	}

	public void Fire ()
	{
		if (magazines [selectedMagazine].remainingBullets > 0) {
			magazines [selectedMagazine].remainingBullets--;
			Debug.Log ("Fire");
			Bullet bullet = magazines [selectedMagazine].bullet;
			GameObject bulletGO = Instantiate (bullet.bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			bulletGO.GetComponent<ExplosiveBulletScript> ().init (bullet);
			bulletGO.GetComponent<Transform> ().localScale *= bullet.scalarFactor;
			bulletGO.GetComponent<MeshRenderer> ().materials [0].color = bullet.color;
			bulletGO.GetComponent<Rigidbody> ().velocity = bullet.speed * bulletGO.transform.forward;

			Destroy (Instantiate (shootExplosionPrefab, bulletSpawn.position, bulletSpawn.rotation), 1.0f);
			Destroy (bulletGO, magazines [selectedMagazine].bullet.time);   
		}
	}

	public void NextMagazine ()
	{
		selectedMagazine = (selectedMagazine + 1) % magazines.Length;
	}
}
