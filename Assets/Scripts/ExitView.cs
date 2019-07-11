using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitView : GameElement {


	void Start()
	{
		//hides Win UI at game start
		app.model.WinUI.SetActive (false);
	}
	void Update()
	{
		//IF statements to Freeze and unfreeze the screen on level complete 
		if (app.model.paused == false) 
		{
			Time.timeScale = 1;

		}

		if (app.model.paused == true) 
		{
			app.model.PauseUI.SetActive (false);
			Time.timeScale = 0;

		}
	}
	//Method that displays exit button at level exit
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player") && app.model.coinCount < 8) 
		{
			app.model.exitText.text = ("Collect 8 coins to exit");
		} 
		else 
		{
			app.model.exitText.text = ("[E] to Enter");
		}
	}

	//Method that displays score
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player") && app.model.coinCount >= 8) 
		{
			if (Input.GetKeyDown (KeyCode.E)) {
				app.model.win = true;
				app.model.paused = true;
				app.model.timerOn = false;
				app.model.WinUI.SetActive (true);
				app.controller.Scoreboard ();
			} 

		}
	}

	//clears exit text when user leaves the collider trigger
	void OnTriggerExit2D(Collider2D col)
	{
		app.model.exitText.text = (" ");
	}
}
