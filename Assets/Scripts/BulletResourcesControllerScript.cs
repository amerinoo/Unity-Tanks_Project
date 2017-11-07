using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletResourcesControllerScript : MonoBehaviour
{
	public GameObject tank;
	public Bullet.Kind kind;

	// Use this for initialization
	void Start ()
	{
		changeColor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void changeColor ()
	{
		Magazine[] magazines = tank.GetComponent<AmmoController> ().magazines;
		Bullet bullet = magazines [Random.Range (0, magazines.Length)].bullet;
		kind = bullet.kind;
		GetComponent<MeshRenderer> ().materials [0].color = bullet.color;
	}
}
