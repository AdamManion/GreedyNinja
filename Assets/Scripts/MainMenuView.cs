using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuView : GameElement {

	public EventSystem eventSystem;
	public GameObject selectedObject;
	public bool buttonSelected;


	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void Quit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	public void Update()
	{

		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false)
		{
			eventSystem.SetSelectedGameObject (selectedObject);
			buttonSelected = true;
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
		
}
