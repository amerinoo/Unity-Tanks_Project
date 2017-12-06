using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrugaScript : MonoBehaviour
{
	public GameObject plate;
	public GameObject ball;
	private Transform UB, UF, DB, DF, BA, FA;
	public bool debug = true;
	public float timeTravel = 0, timeTravel2 = 0;
	public float radius = 0.5f;

	public bool forward = false;

	public void changeDirection ()
	{
		forward = !forward;
		foreach (Plate p in lp) {
			p.changeDirection ();
		} 
	}

	public float linearSpeed {
		set {
			if (forward && value < -0.1f) {
				changeDirection ();
			} else if (!forward && value > 0.1f) {
				changeDirection ();
			}
			timeTravel = Mathf.Abs (value) / 3.0f;
			timeTravel2 = Mathf.Abs (value) * 25;
		}
	}

	List<Plate> lp;

	void Awake ()
	{
		lp = new List<Plate> ();

		UB = transform.Find ("UB");
		UF = transform.Find ("UF");
		DB = transform.Find ("DB");
		DF = transform.Find ("DF");

		BA = transform.Find ("BA");
		FA = transform.Find ("FA");
	}

	void Start ()
	{
		int numRodes = 4 - 1;
		int max = Mathf.RoundToInt (numRodes / (0.2f * 2.0f));
		float z = numRodes * 1.0f / max;

		if (debug) {
			lp.Add (new Plate (this, (radius + 0.1f), z * max - 1.5f));
		} else {
			for (int i = 0; i < max; i++) {
				Plate p;
				p = new Plate (this, (radius + 0.1f), z * i - 1.1f);
				lp.Add (p);

				p = new Plate (this, -(radius + 0.1f), -z * i + 1.1f);
				lp.Add (p);
			}
			int n = 7;
			for (int i = 0; i < n; i++) {
				Plate p;			

				p = new Plate (this, (radius + 0.1f), -1.5f);
				p.Update (0.1f);
				p.Update (i * 0.25f);
				lp.Add (p);

				p = new Plate (this, -(radius + 0.1f), 1.5f);
				p.Update (0.1f);
				p.Update (i * 0.25f);
				lp.Add (p);
			}
		}

	}

	// Update is called once per frame
	void Update ()
	{
		foreach (Plate p in lp) {
			p.Update (Time.deltaTime);
		} 
	}



	class Plate
	{
		private bool endForward;
		private bool endRotate;
		private bool invert;
		private GameObject p;
		private Transform transform;

		OrugaScript os;



		public Plate (OrugaScript os, float y, float z)
		{
			this.os = os;
			transform = os.transform;
			//Quaternion q = os.transform.rotation;
			Quaternion q = Quaternion.Euler (Vector3.zero);

			p = Instantiate (os.plate, new Vector3 (transform.position.x,
				transform.position.y + y, transform.position.z + z), q);
			p.transform.parent = transform;

			endForward = false;
			endRotate = false;
			invert = Mathf.Sign (y) > 0.0f;
		}




		public void Update (float time)
		{
			//Debug.Log (transform.position + " " + p.transform.position + " " + os.ball.transform.position);
			if (endForward)
				Rotate (time);
			else
				Forward (time);

			if (endForward && endRotate) {
				invert = !invert;
				endForward = false;
				endRotate = false;
			}

		}

		private void Forward (float time)
		{
			Vector3 end;
			if (os.forward) {
				end = (invert) ? os.DB.position : os.UF.position;
			} else {
				end = (invert) ? os.UB.position : os.DF.position;
			}
			if (os.debug)
				os.ball.transform.position = end;

			//p.transform.rotation = os.transform.rotation;
			p.transform.position = Vector3.MoveTowards (p.transform.position, end, os.timeTravel * time);
			endForward = Vector3.Distance (p.transform.position, end) < 0.1f;
		}

		private void Rotate (float time)
		{
			Vector3 anchor = (invert) ? os.BA.position : os.FA.position;
			Vector3 end, v;
			if (os.forward) {
				end = (invert) ? os.UB.position : os.DF.position;
				v = transform.right;
			} else {
				end = (invert) ? os.DB.position : os.UF.position;
				v = transform.right * -1.0f;
			}
			if (os.debug)
				os.ball.transform.position = end;
			
			p.transform.RotateAround (anchor, v, os.timeTravel2 * time);
			endRotate = Vector3.Distance (p.transform.position, end) < 0.1f;
		}

		public void changeDirection ()
		{
			if (!endForward) {
				invert = !invert;
				endForward = false;
			}
			

		}
	}
}
