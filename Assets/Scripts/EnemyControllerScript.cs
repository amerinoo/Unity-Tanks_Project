using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : IMove
{
	private float v, h;

	void Start ()
	{
		v = 0.0f;
		h = 0.0f;
		InvokeRepeating ("ChangeDirection", 0, 3);
	}

	bool fire;

	void Update ()
	{
		CheckForward ();
		CheckBackward ();
	}

	void CheckForward ()
	{
		int max = 20;
		int ampleCono = 3;
		for (int i = -max / 2; i < max / 2; i++) {
			Vector3 forward = transform.TransformDirection (new Vector3 (i / (max * 1f) * ampleCono, 0, 1)) * 100;
			Debug.DrawRay (transform.position, forward, Color.green);

			Ray ray = new Ray (transform.position, forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.CompareTag ("Player")) {
					fire = i == 0;
				}
			}
		}
	}

	void CheckBackward ()
	{
		int max = 20;
		int ampleCono = 3;
		for (int i = -max / 2; i < max / 2; i++) {
			Vector3 forward = transform.TransformDirection (new Vector3 (i / (max * 1f) * ampleCono, 0, -1)) * 100;
			Debug.DrawRay (transform.position, forward, Color.green);

			Ray ray = new Ray (transform.position, forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.CompareTag ("Player")) {
					
				}
			}
		}
	}



	public override float GetVertical ()
	{
		return v;
	}

	public override float GetHorizontal ()
	{
		return h;
	}

	public override float GetVerticalTurn ()
	{
		return 0;//Random.Range (-1.0f, 1.0f);
	}

	public override float GetHorizontalTurn ()
	{
		return 0;//Random.Range (-1.0f, 1.0f);
	}

	public override bool Fire ()
	{
		if (fire) {
			fire = false;
			return true;
		}
		return false;
	}

	private void ChangeDirection ()
	{
		v = Random.Range (-1.0f, 1.0f);
		h = Random.Range (-1.0f, 1.0f);
	}

	public override bool NextMagazine ()
	{
		return false;
	}

	public override bool HideBody ()
	{
		return false;
	}

	public override bool CheckDistance ()
	{
		return false;
	}
}
