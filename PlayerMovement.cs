using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameManager manager;
	public float moveSpeed;
	public GameObject deathParticles;

	private float maxSpeed = 5f;
	private Vector3 input;

	private Vector3 spawn;


	// Use this for initialization
	void Start () {
		spawn = transform.position;
		manager = manager.GetComponent<GameManager>();
	}



	void FixedUpdate () {
		input = new Vector3(Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
		{
			GetComponent<Rigidbody>().AddRelativeForce(input * moveSpeed);
		}

		if (transform.position.y < -2)
		{
			Die ();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die ();
		}
		if (other.transform.tag == "Token")
		{
			manager.tokenCount += 1;
			Destroy(other.gameObject);
		}
		if (other.transform.tag == "Goal")
		{
			manager.CompleteLevel();
			manager.currentScore += (manager.currentLevel + 10) * (int)manager.startTime + manager.currentLevel*100;
		}
	}

	void Die()
	{
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));
		transform.position = spawn;
	}
}
