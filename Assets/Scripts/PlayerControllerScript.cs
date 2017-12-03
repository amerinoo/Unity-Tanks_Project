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

	public override bool NextMagazine ()
	{
		return Input.GetButtonDown ("Fire2");
	}

	public override bool HideBody ()
	{
		return Input.GetButtonDown ("Fire3");
	}

	public override bool CheckDistance ()
	{
		return Input.GetButtonDown ("Fire5");
	}
}
