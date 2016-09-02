﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BunnyController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	public float BunnyJump = 500;
	private float bunnyHurtTime = -1;
	private Collider2D myCollider;
	public Text scoreText;
	private float startTime;
	private int count; // To count Carrots
	public Text countText; // To count Carrots

	// Use this for initialization
	void Start () 
	{
		
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator> ();
		myCollider = GetComponent<Collider2D> ();
		startTime = Time.time;
		count = 0; // to count carrots
		SetCountText();
	
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
			scoreText.text = (Time.time - startTime).ToString ("0.0");
		
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
			myCollider.enabled = false;
		}

	}

	void OnTriggerEnter2D (Collider2D other) // to count carrots
	{
		if (other.gameObject.CompareTag ("PickUpCarrot")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();

		}

	}

	void SetCountText()
	{

		countText.text = "Carrots:       " + count.ToString ();
	}





}