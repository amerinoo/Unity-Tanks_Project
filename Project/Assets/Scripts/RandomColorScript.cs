using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		changeColor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			changeColor ();
		}
	}

	void changeColor ()
	{
		foreach (Transform child in transform) {
			child.GetComponent<MeshRenderer> ().materials [0].color = new Color (Random.value, Random.value, Random.value, 1.0f);
		}
	}
}
