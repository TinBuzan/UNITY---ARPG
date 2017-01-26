using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public Texture2D frame;
	public Rect framePosition;
	public Fighter Player;
	public float horizontalDistance;
	public float verticalDistance;
	public float width;
	public float height;
	public mob target;
	public float healthPercent;

	public Texture2D healthBar;
	public Rect healthBarPosition;

	// Use this for initialization
	void Start () 
	{
	     
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Player.opponent != null) 
		{
						target = Player.opponent.GetComponent<mob> ();
						healthPercent = (float)target.health / (float)target.maxHealth;
		} 
		else 
		{
			target = null;
			healthPercent =  0;
		}
	}

	void OnGUI()
	{
		if (target != null&&Player.countDown>0) 
		{
			DrawFrame ();
			DrawBar ();
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



















}
