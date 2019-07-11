using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModel : GameElement
{
	//Timer Variables
	public float timer = 90f;
	public bool timerOn = true;
	public float timerDisplay = 0;


	//Movement
	public float speed = 20f;
	public float jumpPower = 600f;
	public float speedMax = 10f;
	public bool grounded;

	public int nextScene = 0;


	//Pause UI
	public GameObject PauseUI;
	public GameObject WinUI;
	public bool paused = false;
	public bool win = false;


	//UI
	public Text countText;
	public Text timerText;
	public Text winText;

	//Player
	public int playerHealth;
	public int maxHealth = 100;
	public int levelToLoad;
	public Text exitText;
	public int coinCount;


}
