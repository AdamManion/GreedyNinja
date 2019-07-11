using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all the elements in the application.
public class GameElement : MonoBehaviour
{
	// Gives access to the application and all instances.
	public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication> (); } }
}

// Greedy Ninja entry point
public class GameApplication : MonoBehaviour 
{
	//Reference to the root instances of the MVC.
	public GameModel model;
	public GameView view;
	public GameController controller;

}
