﻿using UnityEngine;
using System.Collections;

public class LoadManager : MonoBehaviour {

	public void Loader(int level){
		switch (level) {
		case 0:
			Application.LoadLevel (0);
			break;
		case 1:
			Application.LoadLevel (1);
			break;
		case 2:
			Application.Quit();
			break;
		default:
			Debug.Log("Error cargando nivel...");
			break;
		}
	}
}
