using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	private TankMovementScript tms;
	private ShootScript ss;
	private Transform target;
	float v;
	float h;

	void Start ()
	{
		tms = GetComponent<TankMovementScript> ();
		ss = GetComponent<ShootScript> ();
		InvokeRepeating ("Fire", 1.0f, 1.0f);
		InvokeRepeating ("ChangeDirection", 1.0f, 3.0f);
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Update ()
	{
		if (v < -0.1f)
			tms.MoveBackward (v);
		else if (v > 0.1f)
			tms.MoveForward (v);

		if (h < -0.1f)
			tms.TurnLeft (h);
		else if (h > 0.1f)
			tms.TurnRight (h);
	}

	void ChangeDirection ()
	{
		v = Random.Range (-1.0f, 1.0f);
		h = Random.Range (-1.0f, 1.0f);
	}

	void Fire ()
	{
		ss.Fire ();
	}
}
