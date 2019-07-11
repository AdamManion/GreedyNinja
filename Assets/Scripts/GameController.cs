using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameController : GameElement {



	//Function that reloads the level when the user dies.
	public void Die()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	//Method that inflicts damage to the user
	public void Damage(int dmg)
	{
		app.model.playerHealth -= dmg;
	}

	//Method that updates the coin counter
	public void SetCountText()
	{
		app.model.countText.text = "Coins:" + app.model.coinCount.ToString ();
	}

	public void SetTimerText()
	{
		app.model.timerDisplay = Mathf.Round (app.model.timer * 100f) / 100f;
		app.model.timerText.text = "Timer:" + app.model.timerDisplay.ToString ();

	}

	public void Scoreboard()
	{

		float levelScore = app.model.timerDisplay + (app.model.coinCount * 5);

		app.model.WinUI.SetActive (true);
		Time.timeScale = 0;
		app.model.winText.text = "Well Done! Your score:" + levelScore.ToString ();

	
	}

}
