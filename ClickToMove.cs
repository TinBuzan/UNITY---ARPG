using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public float speed;
	public Vector3 position;
	public CharacterController CharControl;
	public AnimationClip run;
	public AnimationClip idle;
	public static bool attack = false;
	public static bool dieing = false;
	

	// Use this for initialization
	void Start () 
	{
		attack = false;
		dieing = false;
		position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!attack&&!dieing) 
		    {
			if (Input.GetMouseButton (0)) {
					//locate where the player clicked on the terain 
					Locate_Position ();
			}

			MoveToPosition ();
			} 
		else
		{

		}
	}

	//locate position of the user click
	void Locate_Position()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit, 1000))
		{
			if(hit.collider.tag == "Floor")
			position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
		}
	}

	//turn and move the player 
	void MoveToPosition()
	{ 
		//when game object is moving 
		if (Vector3.Distance (transform.position, position) > 1) {
						Quaternion newRotation = Quaternion.LookRotation (position - transform.position);
						newRotation.z = 0f;

						transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
						//transform.position += transform.forward * speed * Time.deltaTime;
						CharControl.SimpleMove (transform.forward * speed );
						
						GetComponent<Animation>().CrossFade(run.name);
				} 
		else 
		{

			GetComponent<Animation>().CrossFade(idle.name);
		}
	}



}















