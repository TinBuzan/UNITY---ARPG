using UnityEngine;
using System.Collections;

public class SepcialAttack : MonoBehaviour {

	public Fighter player;
	public KeyCode key;
	public int StunTime;
	public double heal_percentage;
	public double damage_percentage;
	public bool inAction;
	public GameObject ParticlePrefab;
	private GameObject instantiated;
	private Vector3 lastPos;
	private bool usemove = true;
	public float waittime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Vector3.Distance(lastPos, transform.position) > 0.01f) 
		{ 
			lastPos = transform.position; 

		}	

		if (Input.GetKeyDown (KeyCode.R) && !inAction) {
			player.Heal (heal_percentage, key);
		}

		if (Input.GetKeyDown (key) && usemove) 
		{
			usemove = false;
			player.resetAttack ();
			player.Special_attack = true;
			inAction = true;

			lastPos = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);

			instantiated = (GameObject)Instantiate (ParticlePrefab, 
	        lastPos, transform.rotation);

			StopCoroutine ("Destroy");    // Interrupt in case it's running
			StartCoroutine ("Destroy");
		}
			

		if (inAction) 
		{
			if(player.opponent!= null)
			{
				player.Attack (StunTime, damage_percentage, key);
			}
			if (GetComponent<Animation>()[player.attack.name].time > 0.9*GetComponent<Animation>()[player.attack.name].length)
			{
				inAction = false;
				player.Special_attack = false;
			}
		}
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(waittime);
		if (instantiated != null)
		{
			Destroy(instantiated); 
			usemove = true;
		}
		player.Special_attack = false;
		inAction = false;
	}























}
