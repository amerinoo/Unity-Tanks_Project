using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizer : MonoBehaviour
{
	public int maxVerticalInclination = 30;
	Rigidbody rb;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 vc = transform.localEulerAngles;
		if (vc.z > 1 && vc.z < 359) {
			rb.angularVelocity = Vector3.zero;
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.eulerAngles.y, 0);
		}

		if (vc.x > maxVerticalInclination && vc.x < 360 - maxVerticalInclination) {
			rb.angularVelocity = Vector3.zero;
			float f;
			if (vc.x < 180)
				f = transform.localEulerAngles.x * 2 / 3.0f;
			else
				f = (transform.localEulerAngles.x * 2 + 360) / 3.0f;

			transform.localEulerAngles = new Vector3 (f, transform.eulerAngles.y, 0);
		}
	}
}
