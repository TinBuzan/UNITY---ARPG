	using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	//we need 100 exp to level up 
	public int Level;
	public int exp;
	public int expNeeded;
	public Fighter Player;

	// Use this for initialization
	void Start () 
	{
		expNeeded =(int)(Mathf.Pow(Level,2)+100);
	}
	
	// Update is called once per frame
	void Update () 
	{

		LevelUp ();
	}

	void LevelUp()
	{
		// we will make an  exponetial leveling system ^3 +100
		if (exp >= expNeeded) 
		{
			expNeeded =(int)(Mathf.Pow(Level,2)+100 + (expNeeded*Level));
			Level = Level+1;
			exp = exp - (int)(Mathf.Pow(Level,2)+100);
			LevelEffect();
		}

	}

	//Expand the levelEffect
	void LevelEffect()
	{
		Player.maxHealth +=100;
		Player.damage +=(int)Mathf.Pow(Level,2)+20;
		Player.Health = Player.maxHealth;
	}







}
