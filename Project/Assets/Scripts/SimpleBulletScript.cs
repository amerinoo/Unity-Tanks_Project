using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletScript : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		Destroy (gameObject);
	}
}
