using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelScript : MonoBehaviour
{
	public GameObject gameOptions;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void StartLevel ()
	{
		SceneManager.LoadScene (StaticData.GameScreen);
	}

	public void ShowGameOptions ()
	{
		gameOptions.SetActive (true);
	}

	
}
