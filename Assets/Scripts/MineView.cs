using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineView : GameElement {


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			app.controller.Damage (100);
		}
	}
}
