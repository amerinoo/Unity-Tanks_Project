using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRandomCubesScript : MonoBehaviour
{

	public Transform plane;
	public GameObject cubes;
	public int max;
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < max; i++) {
			GameObject go = Instantiate (cubes, new Vector3 (Random.Range (-200.0f, 200.0f), 0.0f, Random.Range (-200.0f, 200.0f)), Quaternion.Euler (0.0f, Random.Range (0.0f, 90.0f), 0.0f));
			go.name = "Cubes " + i;
			go.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
