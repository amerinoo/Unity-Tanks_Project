using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameData : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void HandleDifficulty (bool b)
	{
		StaticData.easy = b;
	}

	public void HandleTankModel (bool b)
	{
		StaticData.tank = b ? "Unity" : "Blender";
	}

	public void HandleMap (bool b)
	{
		StaticData.scenario = b ? "Sandbox" : "Mountains";
	}
}
