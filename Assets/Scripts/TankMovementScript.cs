using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementScript : MonoBehaviour
{
	public float speedLinear = 15.0f;
	public float speedRotate = 1.0f;
	public float bulletSpeed = 80.0f;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	private Rigidbody rb;
	private List<Transform> continuousTracks;
	private float forward, left;

	void Start ()
	{
		rb = GetComponent<Rigidbody> () as Rigidbody;
		//turret = transform.Find ("Turret");
		continuousTracks = new List<Transform> ();
		foreach (Transform child in transform) {
			if (child.CompareTag ("ContinuousTrack"))
				continuousTracks.Add (child);
		}
	}

	void Update ()
	{
		float axisH = Input.GetAxis ("Horizontal");
		float factor = 0.5f + axisH / -2.0f * 0.5f;
		if (rb.velocity.magnitude < 0.1f && Mathf.Abs (axisH) > 0.1f) {
			continuousTracks [0].GetComponent<ContinousTrackScript> ().linearSpeed = speedLinear * -left * 0.5f;
			continuousTracks [1].GetComponent<ContinousTrackScript> ().linearSpeed = speedLinear * left * 0.5f;
		} else {
			continuousTracks [0].GetComponent<ContinousTrackScript> ().linearSpeed = rb.velocity.magnitude * forward * factor;
			continuousTracks [1].GetComponent<ContinousTrackScript> ().linearSpeed = rb.velocity.magnitude * forward * (1 - factor);
		}

	}

	public void MoveForward (float h = 1.0f)
	{
		forward = 1.0f;
		rb.velocity = transform.forward * speedLinear * h;
	}

	public void MoveBackward (float h = -1.0f)
	{
		forward = -1.0f;
		rb.velocity = transform.forward * speedLinear * h;
	}

	public void TurnLeft (float v = -1.0f)
	{
		left = -1.0f;
		rb.MoveRotation (Quaternion.Euler (0.0f, speedRotate * v, 0.0f) * rb.rotation);
	}

	public void TurnRight (float v = 1.0f)
	{
		left = 1.0f;
		rb.MoveRotation (Quaternion.Euler (0.0f, speedRotate * v, 0.0f) * rb.rotation);
	}


	[SerializeField]
	public GameObject explosionPrefab;

	public void Fire ()
	{
		Debug.Log ("Fire");
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * bulletSpeed;
		Instantiate (explosionPrefab, bulletSpawn.position, bulletSpawn.rotation);
		// Destroy the bullet after 3 seconds
		Destroy (bullet, 3.0f);        
	}

	public void HideBody ()
	{
		GameObject go = transform.Find ("Body").gameObject;
		go.SetActive (!go.activeSelf);
	}
}
