using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	public bool pause;
	public GameObject player;
	public bool playerDead;

	private UIControllerScript uics;

	// Use this for initialization
	void Start ()
	{
		player = Instantiate (Resources.Load ("Tanks/" + StaticData.tank))as GameObject;
		GameObject go = Instantiate (Resources.Load ("Scenarios/" + StaticData.scenario))as GameObject;
		GameObject.FindGameObjectWithTag ("Player").transform.position = go.transform.Find ("Skeleton/InitialPoint").transform.position;
		uics = GetComponent<UIControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}

		if (pause) {
			
		} else {
			if (PlayerDead ())
				EndGame ();
			
		}
	}

	bool PlayerDead ()
	{
		return playerDead;
	}

	public void PlayerDead (int playerNum)
	{
		playerDead = true;
	}

	public void Pause ()
	{
		pause = true;
		uics.Pause ();
		Time.timeScale = 0.0f;
	}

	public void Resume ()
	{
		pause = false;
		uics.Resume ();
		Time.timeScale = 1.0f;
	}

	public void EndGame ()
	{
		Pause ();
	}

	public void GoMenu ()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene (StaticData.MainScreen);
	}


	void OnApplicationPause (bool pauseStatus)
	{
		
		if (pauseStatus)
			Pause ();
	}
}
