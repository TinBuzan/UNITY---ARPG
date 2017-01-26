using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Label (new Rect(10,10, 350,75), "Skull Crusher");
		if (PlayerPrefs.GetInt("Level Completed") > 0)
		{
				if(PlayerPrefs.GetInt("Level Completed") != 10)
				{
				if (GUI.Button(new Rect(10,100,100,45), "Continue"))
				{
				Application.LoadLevel(PlayerPrefs.GetInt("Level Completed"));
				}
			    }
		}
		if (GUI.Button(new Rect(10,155,100,45), "New Game"))
		{
			PlayerPrefs.SetInt("Level Completed", 0);
			Application.LoadLevel(1);
			Cursor.visible = false;
		}
	}
}
