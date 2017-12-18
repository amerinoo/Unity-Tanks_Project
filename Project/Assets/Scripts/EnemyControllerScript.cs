using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : IMove
{
	public float v, h;
	public float safeDistance = 40;
	public bool easy;

	void Start ()
	{
		v = 0.0f;
		h = 0.0f;
		InvokeRepeating ("ChangeDirection", 0, 3);
	}

	bool fire;

	void Update ()
	{
		if (easy) {
			LookEasy (true); // Forward
			LookEasy (false); // Backward
		} else {
			LookHard (true); // Forward
			LookHard (false); // Backward
		}
	}

	void LookEasy (bool isForward)
	{
		Vector3 forward = transform.forward * 100;
		Ray ray = new Ray (transform.position, forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.CompareTag ("Player")) {
				Debug.DrawRay (transform.position, forward, Color.red);
				if (isForward)
					fire = true;
			} else {
				Debug.DrawRay (transform.position, forward, Color.green);
			}
		}
	}

	void LookHard (bool isForward)
	{
		int max = 20 + 1;
		int ampleCono = 3;
		List<int> d = new List<int> ();
		float dist = 0;
		for (int i = -max / 2; i < max / 2; i++) {
			Vector3 forward = transform.TransformDirection (new Vector3 (i / (max * 1f) * ampleCono, 0, (isForward ? 1 : -1))) * 100;

			Ray ray = new Ray (transform.position, forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.transform.CompareTag ("Player")) {
					Debug.DrawRay (transform.position, forward, Color.red);
					if (isForward)
						fire = i == 0;
					d.Add (i);
					dist = hit.distance;
				} else {
					Debug.DrawRay (transform.position, forward, Color.green);
				}
			}
		}
		float average = Average (d);
		if (average != 0) {
			h = average / max / 2;
			h = (1 - Mathf.Abs (h)) * Mathf.Sign (h);
			v = RectifyNumber (isForward, h);
			v = dist < safeDistance ? 0 : v;
			//Debug.Log (average + " " + v + " " + h + " " + dist);
		}
	}

	float RectifyNumber (bool positive, float num)
	{
		return Mathf.Abs (num) * (positive ? 1 : -1);
	}

	float Average (List<int> d)
	{
		int sum = 0;
		foreach (int item in d) {
			sum += item;
		}
		return d.Count != 0 ? sum / (d.Count * 1.0f) : 0.0f;
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
