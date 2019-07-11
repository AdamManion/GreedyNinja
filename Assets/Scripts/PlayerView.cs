 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : GameElement
{
	// Use this for initialization
	public void Start () {		
		//initalizes the players ridgidboy and allows script to work with it
		//app.model. rb2d = gameObject.GetComponent<Rigidbody2D> ();

		//initalizes the players health to equal the maximum
		app.model.playerHealth = app.model.maxHealth;
		app.model.coinCount = 0;
		app.controller.SetCountText ();

	}

	public void Update()
	{
		//References to Animation Variables
		app.view.player.GetComponentInChildren<Animator> ().SetBool ("Grounded", app.model.grounded);
		app.view.player.GetComponentInChildren<Animator> ().SetFloat("Speed", Mathf.Abs(app.view.player.GetComponent<Rigidbody2D>().velocity.x));

		//check to make sure the sprite is facing the correct way
		if(Input.GetAxis("Horizontal") < -0.1f)
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if(Input.GetAxis("Horizontal") > 0.1f)
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}


		//jump functionality
		if (Input.GetButtonDown ("Jump") && app.model.grounded == true){
			app.view.player.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * app.model.jumpPower);
		}

		//kills the user if their health reaches 0
		if (app.model.playerHealth <= 0) 
		{
			app.controller.Die();
		}

		//Game Timer
		if (app.model.timerOn) 
		{
			app.model.timer -= Time.deltaTime;
		}

		//If statement that calls the method that updates the timer UI
		if (app.model.timer > 0) 
		{
			app.controller.SetTimerText ();
		}

		//If statement that kills the player if the timer reaches 0
		if (app.model.timer < 0) 
		{
			app.controller.Die ();
		}


	}

	void FixedUpdate()
	{
		float horizontalMovement = Input.GetAxis ("Horizontal");

		// horizontal player movement
		app.view.player.GetComponent<Rigidbody2D> ().AddForce ((Vector2.right * app.model.speed) * horizontalMovement);

		//Max speed
		if (app.view.player.GetComponent<Rigidbody2D> ().velocity.x > app.model.speedMax)
		{
			app.view.player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (app.model.speedMax, app.view.player.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if(app.view.player.GetComponent<Rigidbody2D> ().velocity.x < -app.model.speedMax)
		{
			app.view.player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-app.model.speedMax, app.view.player.GetComponent<Rigidbody2D> ().velocity.y);
		}

	}

	//method for collecting coins
	void OnTriggerEnter2D(Collider2D col)
	{
		app.model.grounded = true;

		if (col.gameObject.CompareTag ("Pick Up")) 
		{
			col.gameObject.SetActive (false);
			app.model.coinCount += 1; 
			app.controller.SetCountText ();
		}
	}

	//Methods to check if the player is on the ground
	void OnTriggerStay2D(Collider2D col)
	{
		app.model.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		app.model.grounded = false;
	}
}
