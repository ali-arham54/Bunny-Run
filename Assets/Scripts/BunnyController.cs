using UnityEngine;
using System.Collections;

public class BunnyController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	public float BunnyJump = 500;
	private float bunnyHurtTime = -1;

	// Use this for initialization
	void Start () 
	{
		
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator> ();
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (bunnyHurtTime == -1) 
		{	
			if (Input.GetButtonUp ("Jump")) 
			{
				myRigidBody.AddForce (transform.up * BunnyJump);

			}

			myAnim.SetFloat ("vVelocity", myRigidBody.velocity.y);
		
		}

		else 
		{
			if (Time.time > bunnyHurtTime + 2) 
			{
				Application.LoadLevel (Application.loadedLevel);

			}
		
		}
	
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) 
		{
			foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>()) 
			{

				spawner.enabled = false;

			}

			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) 
			{
			
				moveLefter.enabled = false;
			
			}
				
			//Application.LoadLevel (Application.loadedLevel);
			bunnyHurtTime = Time.time;
			myAnim.SetBool ("BunnyHurt", true);
			myRigidBody.velocity = Vector2.zero;
			myRigidBody.AddForce (transform.up * BunnyJump);
		}

	}
}