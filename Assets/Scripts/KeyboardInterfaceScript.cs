using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInterfaceScript : MonoBehaviour
{
	private TankMovementScript tms;

	void Start ()
	{
		tms = GetComponent<TankMovementScript> ();
	}

	void Update ()
	{
		float v;
		float h;
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");

		if (v < -0.1f)
			tms.MoveBackward (v);
		else if (v > 0.1f)
			tms.MoveForward (v);


		if (h < -0.1f)
			tms.TurnLeft (h);
		else if (h > 0.1f)
			tms.TurnRight (h);

		if (Input.GetButtonDown ("Fire1")) {
			tms.Fire ();
		}

		if (Input.GetKeyDown (KeyCode.H)) {
			tms.HideBody ();
		}
	}
}
