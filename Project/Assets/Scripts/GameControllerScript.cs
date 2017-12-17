using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	public bool pause;
	public List<GameObject> players;
	public GameObject scenario;
	public int playersCount;
	public int botsCount;
	public bool debug;

	private UIControllerScript uics;

	// Use this for initialization
	void Start ()
	{
		if (debug) {
			scenario = GameObject.Find ("Remove").transform.GetChild (0).gameObject;
		} else {
			GameObject.Find ("Remove").SetActive (false);
			scenario = Instantiate (Resources.Load ("Scenarios/" + StaticData.scenario))as GameObject;
			putTanks ("Players", "Player", true);
		}
		playersCount = players.Count;
		putTanks ("Bots", "Bot", false);
		botsCount = players.Count;
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
			if (!PlayersAlive ()) {
				Debug.Log ("Bots win");
				EndGame ();
			} else if (!BotsAlive ()) {
				Debug.Log ("Players win");
				EndGame ();
			}
			
		}
	}

	private void putTanks (string skeletonTag, string tag, bool isPlayer)
	{
		GameObject go;
		int initialCount = players.Count;
		foreach (Transform tra in scenario.transform.Find ("Skeleton/" + skeletonTag)) {
			go = Instantiate (Resources.Load ("Tanks/" + StaticData.tank))as GameObject;
			go.transform.position = tra.position;
			go.transform.Find ("Tank controller").transform.tag = tag;
			go.transform.Find ("Tank controller").GetComponent<TankController> ().isPlayer = isPlayer;
			go.transform.Find ("Tank controller").GetComponent<TankController> ().index = players.Count - initialCount;
			go.transform.Find ("Tank controller").GetComponent<HealthManagementScript> ().index = players.Count;
			if (players.Count != 0) {
				go.transform.Find ("Tank controller/Turret/Camera").GetComponent<AudioListener> ().enabled = false;
			}
			go.name = tag + " " + (players.Count - initialCount + 1).ToString ();
			foreach (Transform text in go.transform.Find ("Tank controller/Texts")) {
				text.GetComponent<TextMesh> ().text = go.name;
			}
			go.transform.SetParent (transform.Find (skeletonTag));
			players.Add (go);
		}
	}

	bool PlayersAlive ()
	{
		for (int i = 0; i < playersCount; i++)
			if (players [i].activeSelf)
				return true;
		return false || playersCount == 0;
	}

	bool BotsAlive ()
	{
		for (int i = playersCount; i < players.Count; i++)
			if (players [i].activeSelf)
				return true;
		return false || botsCount == 0;
	}

	public void PlayerDead (int playerNum)
	{
		Debug.Log (playerNum);
		players [playerNum].SetActive (false);
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
		GoMenu ();
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
