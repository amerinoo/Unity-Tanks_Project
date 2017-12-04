using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
	public bool isPlayer;
	private IMove controller;
	private TankMovementScript tms;
	private ShootScript ss;

	GameControllerScript gc;

	void Start ()
	{
		transform.Find ("Camera").gameObject.SetActive (isPlayer);
		transform.Find ("Minimap camera").gameObject.SetActive (isPlayer);
		transform.Find ("HUD").gameObject.SetActive (isPlayer);
		if (isPlayer)
			controller = gameObject.AddComponent<PlayerControllerScript> ();
		else
			controller = gameObject.AddComponent<EnemyControllerScript> ();

		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ();

		tms = GetComponent<TankMovementScript> ();
		ss = GetComponent<ShootScript> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gc.pause) {
			return;
		}
		float v, vt;
		float h, ht;
		v = controller.GetVertical ();
		h = controller.GetHorizontal ();
		vt = controller.GetVerticalTurn ();
		ht = controller.GetHorizontalTurn ();

		if (v < -0.1f)
			tms.MoveBackward (v);
		else if (v > 0.1f)
			tms.MoveForward (v);

		if (h < -0.1f)
			tms.TurnLeft (h);
		else if (h > 0.1f)
			tms.TurnRight (h);

		if (vt < -0.1f)
			tms.TurnTurretUp (vt);
		else if (vt > 0.1f)
			tms.TurnTurretDown (vt);

		if (ht < -0.1f)
			tms.TurnTurretLeft (ht);
		else if (ht > 0.1f)
			tms.TurnTurretRight (ht);

		if (controller.Fire ())
			ss.Fire ();

		if (controller.NextMagazine ())
			ss.NextMagazine ();

		if (controller.HideBody ())
			tms.HideBody ();

		if (controller.CheckDistance ())
			ss.CheckDistance ();
	}
}
