using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MenuController : MonoBehaviour {






	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {



	}


	public void PauseGame (){
	
	

			if (Time.timeScale == 1) {
		
				Time.timeScale = 0;

			} else if (Time.timeScale == 0) {
		
				Time.timeScale = 1;

		
			}

		

	}




	public void StartGame (){
	
		Application.LoadLevel ("Main Scene");

	
	}

	public void MainMenu (){
	
		Application.LoadLevel ("Title Scene");
	
	}

	public void QuitGame (){

		Application.Quit ();

	}




}
