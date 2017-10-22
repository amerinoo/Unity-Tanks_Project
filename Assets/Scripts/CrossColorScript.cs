using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossColorScript : MonoBehaviour
{
	private Color color;

	public Color Color {
		get {
			return color;
		}
		set {
			color = value;
		}
	}

	// Use this for initialization
	void Start ()
	{
		color = transform.GetChild (0).GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ChangeColor (Color c)
	{
		color = c;
		foreach (Transform child in transform) {
			child.GetComponent<Image> ().color = c;
		}
	}
		
}
