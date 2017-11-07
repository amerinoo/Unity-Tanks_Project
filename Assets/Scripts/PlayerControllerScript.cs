using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerScript : IMove
{
	void Start ()
	{
	}

	void Update ()
	{
	}

	public override float GetVertical ()
	{
		return Input.GetAxis ("Vertical");
	}

	public override float GetHorizontal ()
	{
		return Input.GetAxis ("Horizontal");
	}

	public override float GetVerticalTurn ()
	{
		return Input.GetAxis ("VerticalTurn");
	}

	public override float GetHorizontalTurn ()
	{
		return Input.GetAxis ("HorizontalTurn");
	}

	public override bool Fire ()
	{
		return Input.GetButtonDown ("Fire1");
	}
}
