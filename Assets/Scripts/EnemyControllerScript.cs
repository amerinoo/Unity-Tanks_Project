using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : IMove
{
	private float v, h;

	void Start ()
	{
		v = 0.0f;
		h = 0.0f;
		InvokeRepeating ("ChangeDirection", 0, 3);
	}

	void Update ()
	{
		
	}

	public override float GetVertical ()
	{
		return v;
	}

	public override float GetHorizontal ()
	{
		return h;
	}

	public override float GetVerticalTurn ()
	{
		return 0;//Random.Range (-1.0f, 1.0f);
	}

	public override float GetHorizontalTurn ()
	{
		return 0;//Random.Range (-1.0f, 1.0f);
	}

	public override bool Fire ()
	{
		return true;
	}

	private void ChangeDirection ()
	{
		v = Random.Range (-1.0f, 1.0f);
		h = Random.Range (-1.0f, 1.0f);
	}
}
