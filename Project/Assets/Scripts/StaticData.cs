using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
	public static int MainScreen = 0;
	public static int GameScreen = 1;
	public static int CreditsScreen = 2;

	public static string scenario = "Sandbox";
	public static string tank = "Simple";

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public static string GetCredits ()
	{
		return 
		"***Programmers***\n" +
		"Albert Eduard Merino Pulido\n\n\n\n" +
		"***Artists (Blender) and animations***\n" +
		"Albert Eduard Merino Pulido\n\n\n\n" +
		"***Fonts***\n" +
		"https://www.dafont.com/es/comical_cartoon.font\n\n\n\n" +
		"***Music***\n" +
		"https://www.dl-sounds.com/royalty-free/platformer2/\n\n\n\n" +
		"***Professors***\n" +
		"Francisco Sebe Feixas\n\n\n\n" +
		"***Author***\n" +
		"Albert Eduard Merino Pulido\n" +
		"https://github.com/amerinoo/Unity-Tanks-Project\n\n\n\n" +
		"***Subject information***\n" +
		"Video game development for high performance platforms\n" +
		"Academic year 2017-18\n" +
		"University of Lleida";
		//https://www.youtube.com/watch?v=UyOj5m7y0EI
	}
}
