using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousTrackScript : MonoBehaviour
{

	public float linearSpeed {
		set {
			foreach (Transform child in transform) {
				if (child.CompareTag ("Wheel")) {
					child.GetComponent<WheelScript> ().linearSpeed = value;
				}
			}
			transform.GetComponent<OrugaScript> ().linearSpeed = value * 2.0f;
		}
	}
}