using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUps : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("is triggered");
		Destroy (gameObject);

	}






}
