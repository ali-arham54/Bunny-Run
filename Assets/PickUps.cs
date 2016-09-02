using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUps : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Destroy (gameObject);
	}






}
