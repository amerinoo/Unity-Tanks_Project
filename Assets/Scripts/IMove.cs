using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMove : MonoBehaviour
{
	void Start ()
	{
	}

	void Update ()
	{
	}

	public abstract float  GetVertical ();

	public abstract float GetHorizontal ();

	public abstract float  GetVerticalTurn ();

	public abstract float  GetHorizontalTurn ();

	public abstract bool  Fire ();

	public abstract bool NextMagazine ();

	public abstract bool HideBody ();

	public abstract bool CheckDistance ();
}
