using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public Texture2D frame;
	public GUIText Level;
	public GUIText Exp;
	public GUIText DeathNote;
	public Texture2D Death;
	public LevelSystem Playerlevel;
	public Rect framePosition;
	public Fighter Player;
	public float horizontalDistance;
	public float verticalDistance;
	public float width;
	public float height;
	public float healthPercent;
	public Texture2D healthBar;
	public Rect healthBarPosition;
    Rect DP;
	
	// Use this for initialization
	void Start () 
	{
		framePosition.y = Screen.height * 0.9f;
		DP = new Rect ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit ();
		}

		DrawExp_Level();

		if (Player != null) 
		{
			healthPercent = (float)Player.Health / (float)Player.maxHealth;
		} 
		else 
		{
			healthPercent =  0;
		}
	}
	
	void OnGUI()
	{
		if (Player != null) 
		{
			DrawFrame ();
			DrawBar ();
		}
		if (Player.Health <= 0) 
		{
			SetDeathNote();
		}
	}
	
	
	void DrawFrame()
	{
		framePosition.x = (Screen.width - framePosition.width) /2;
		float width = 200 / 0.39f;
		//for added compretion 
		//framePosition.width = Screen.width* width;
		//framePosition.height = Screen.height / 0.0625;
		GUI.DrawTexture (framePosition,frame);
	}
	
	void DrawBar()
	{
		healthBarPosition.x = framePosition.x + (framePosition.width * horizontalDistance);
		healthBarPosition.y = framePosition.y + (framePosition.height * verticalDistance);
		healthBarPosition.width = framePosition.width * width* healthPercent;
		healthBarPosition.height = framePosition.height * height;
		GUI.DrawTexture (healthBarPosition,healthBar);
	}

	void DrawExp_Level()
	{
		if (Playerlevel != null) 
		{
			Level.text = "Level "+Playerlevel.Level;
			Exp.text =   "Exp " + Playerlevel.exp + "  [ "+Playerlevel.expNeeded+" ]";
		}
	}

	void SetDeathNote()
	{
		//DeathNote.text = "You  Died";
		DP.width = 300;
		DP.height = 90;
		DP.x = Screen.width * 0.5f - (DP.width * 0.5f);
		DP.y =  Screen.height * 0.5f;
		GUI.DrawTexture (DP,Death);

		if (Input.anyKey) 
		{
			Application.LoadLevel("rpg game 1");
		}
	}





}
