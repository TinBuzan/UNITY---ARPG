using UnityEngine;
using System.Collections;

public class Screenfade : MonoBehaviour {

	public float fadeSpeed = 1.5f;
	private bool scenestarting = true;

	public void Awake()
	{
		GetComponent<GUITexture>().pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}

	void Update()
	{
		if (scenestarting) 
		{
			StartScene();
		}
	}

	void fadeToClear()
	{
		GetComponent<GUITexture>().color = Color.Lerp (GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void fadeToBlack()
	{
		GetComponent<GUITexture>().color = Color.Lerp (GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		fadeToClear();
		if (GetComponent<GUITexture>().color.a <= 0.05f)
		{
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;
			scenestarting = false;
		}
	}

	public void EndScene()
	{
		GetComponent<GUITexture>().enabled = true;
		fadeToBlack ();
		if (GetComponent<GUITexture>().color.a >= 0.95f)
		{
			Application.LoadLevel(1);
		}
	}




}
