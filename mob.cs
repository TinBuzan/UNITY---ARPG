using UnityEngine;
using System.Collections;

public class mob : MonoBehaviour {

	public float speed;
	public float range; // how far an object needs to be in order to hit player
	public float chaseRange;
	public Transform player;
	public CharacterController control;
	public AnimationClip run;
	public LevelSystem playerLevel;
	public AnimationClip idel;
	public int maxHealth;
	public int health;
	public int damage;
	public int exp_Value;
	public AnimationClip die;
	public AnimationClip attacks;
	public double ImpactTime = 0.36;
	private bool impacted = false;
	private Fighter opponent;
	private int stunTime;

	// Use this for initialization
	void Start () 
	{
		health = maxHealth;
		opponent = player.GetComponent<Fighter> ();
	}
	
	// Update is called once per frame
	// Constantly checks if we are dead
	void FixedUpdate () 
	{
		if (IsDead() == false) 
		{
			if(!inRange(chaseRange)) return;
			if(stunTime<=0)
			{
			if (!inRange (range)) 
			{
					chase ();
			} else {
					//animation.CrossFade (idel.name);
			attack();
				if (GetComponent<Animation>()[attacks.name].time > 0.9*GetComponent<Animation>()[attacks.name].length)
				{
					impacted = false;
				}
			}
		   }
			else
			{
			}
		} else
		  staydead ();
	}

	public void GetStun(int seconds)
	{
		stunTime = seconds;
		InvokeRepeating ("stunCountDown",0f,1f);

	}

	bool inRange(float range)
	{
		if (Vector3.Distance (transform.position, player.position) < range) 
		{
		 return true;
		} else
		return false;
	}

	public void getHit(int damage)
	{
		health = health - damage;
		if (health < 0) 
		{
			health = 0;
		}
	}

	void chase()
	{
		transform.LookAt (player.position);
		//transform.position += transform.forward * speed * Time.deltaTime;
		control.SimpleMove (transform.forward * speed);
		GetComponent<Animation>().Play (run.name);
	}

	void OnMouseOver()
	{
		player.GetComponent<Fighter> ().opponent = gameObject;
		player.GetComponent<Fighter> ().setCombatCountdown ();
	}

	bool IsDead()
	{
		if (health <= 0) 
		{
			return true;
		}
		return false;
	}

	void staydead()
	{
		// Once the animation has completed 90% we are officially dead
		if(GetComponent<Animation>()[die.name].time> GetComponent<Animation>()[die.name].length*0.9)
		{
			playerLevel.exp += exp_Value;
			Destroy(gameObject);
		}
		GetComponent<Animation>().Play (die.name);
	}

	void stunCountDown()
	{
		stunTime -= 1;
		if (stunTime == 0) 
		{
			CancelInvoke("stunCountDown");
		}
	}
	
	void attack()
	{
		GetComponent<Animation>().Play (attacks.name);

		if (GetComponent<Animation>() [attacks.name].time > ImpactTime&!impacted&&
		    GetComponent<Animation>()[attacks.name].time < 0.9*GetComponent<Animation>()[attacks.name].length) 
		{
			impacted =true;
			opponent.Get_Hit(damage);
		}
	}

















}


























