using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
	private float angularSpeed;
	private float radius;

	// Use this for initialization
	void Start ()
	{
		angularSpeed = 0;
		radius = transform.localScale.z / 2.0f;

	}

	void Update ()
	{
		transform.Rotate (Vector3.up * angularSpeed);	
	}

	public float linearSpeed {
		set {
			this.angularSpeed = value / radius;
		}
	}
}
