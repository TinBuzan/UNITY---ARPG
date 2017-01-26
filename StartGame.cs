using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Screenfade fade;
    bool endscene = false;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	 if (Input.anyKey) 
		{
			endscene = true;
		}
		if (endscene == true) 
		{
			fade.EndScene ();
		}
	}
}
