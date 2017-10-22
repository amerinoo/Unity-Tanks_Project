using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardInterfaceScript : MonoBehaviour
{
	private TankMovementScript tms;
	private ShootScript ss;

	void Start ()
	{
		tms = GetComponent<TankMovementScript> ();
		ss = GetComponent<ShootScript> ();
	}

	void Update ()
	{
		float v, vt;
		float h, ht;
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		vt = Input.GetAxis ("VerticalTurn");
		ht = Input.GetAxis ("HorizontalTurn");

		if (v < -0.1f)
			tms.MoveBackward (v);
		else if (v > 0.1f)
			tms.MoveForward (v);

		if (h < -0.1f)
			tms.TurnLeft (h);
		else if (h > 0.1f)
			tms.TurnRight (h);
		
		if (vt < -0.1f)
			tms.TurnTurretDown (vt);
		else if (vt > 0.1f)
			tms.TurnTurretUp (vt);

		if (ht < -0.1f)
			tms.TurnTurretLeft (ht);
		else if (ht > 0.1f)
			tms.TurnTurretRight (ht);

		if (Input.GetButtonDown ("Fire1"))
			ss.Fire ();
		
		if (Input.GetButtonDown ("Fire2"))
			ss.NextMagazine ();

		if (Input.GetButtonDown ("Fire3"))
			tms.HideBody ();
		
		if (Input.GetButtonDown ("Fire4"))
			SceneManager.LoadScene ("main");

		if (Input.GetButtonDown ("Fire5"))
			ss.CheckDistance ();
		
	}
}
