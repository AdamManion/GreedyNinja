using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIView : GameElement {

	void Start()
	{
		//sets PauseUI to not active at the start
		app.model.PauseUI.SetActive (false);

	}

	void Update()
	{
		//if statement that pauses the game on users input
		if (Input.GetButtonDown ("Pause")) 
		{
			app.model.paused = !app.model.paused;
		}
		//If statements that show and hide the pause menu
		if (app.model.paused && app.model.win == false) 
		{
			app.model.PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!app.model.paused) 
		{
			app.model.PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//Method to give the resume button functionality
	public void Resume()
	{
		//Resumes play
		app.model.paused = false;
	}

	//Method to give the restart button functionality
	public void Restart()
	{
		//Restarts level
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
	{
		//Takes you to the main menu
		SceneManager.LoadScene (0);

	}

	public void NextLevel()
	{
		//Loads next level
		app.model.nextScene = SceneManager.GetActiveScene ().buildIndex + 1;
		SceneManager.LoadScene (app.model.nextScene);
	}

	public void Quit()
	{
		//Quits editor and game
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
