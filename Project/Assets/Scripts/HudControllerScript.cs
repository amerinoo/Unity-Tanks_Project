using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudControllerScript : MonoBehaviour
{
	public GameObject bulletsCounter;
	public GameObject healthCounter;
	public GameObject cross;

	private Image background;
	private Text bulletsText;
	private Text healthText;
	private CrossColorScript ccs;
	private float time = 1.0f;

	// Use this for initialization
	void Start ()
	{
		background = bulletsCounter.transform.Find ("Background").GetComponent<Image> ();
		bulletsText = bulletsCounter.transform.Find ("BulletsText").GetComponent<Text> ();
		healthText = healthCounter.transform.Find ("HealthText").GetComponent<Text> ();
		ccs = cross.GetComponent<CrossColorScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ccs.ChangeColor (Color.Lerp (ccs.Color, Color.white, time * Time.deltaTime));
	}

	public void UpdateHUD (Color c, int remainingBullets, int maxBullets)
	{
		background.color = c;
		bulletsText.color = (new Vector3 (c.g, c.r, c.b).magnitude > 1.0f) ? Color.black : Color.white;
		bulletsText.text = string.Format ("{0} / {1}", remainingBullets, maxBullets);
	}

	public void UpdateHUD (float health)
	{
		healthText.text = health.ToString ();
	}

	public void CheckDistance (bool correct)
	{
		ccs.ChangeColor ((correct) ? Color.green : Color.red);
	}

	public void DeactivateHud ()
	{
		bulletsCounter.transform.parent.gameObject.SetActive (false);
	}
}
