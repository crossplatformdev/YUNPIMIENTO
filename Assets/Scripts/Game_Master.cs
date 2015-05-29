using UnityEngine;
using System.Collections;

public class Game_Master : MonoBehaviour {

	// ----------------------- Singleton ---------------------

	private static Game_Master _GMinstance;

	public static Game_Master GMinstance{

		get{

			if(_GMinstance == null)
				_GMinstance = GameObject.FindObjectOfType<Game_Master>();

			return GMinstance;

		}


	}

	// --------------------- Atributos -----------------------


	private static bool gameOver;
	private static bool gameWon;


	// --------------------- Inicializacion ------------------

	void Start(){

		gameOver = false;
		gameWon = false;

	}

	void Update(){

		if(Input.GetButtonDown ("Pause")) PauseGame ();

	}

	// ------------------ Metodos y Funcionalidad ------------



	public void PauseGame(){

		print ("Pausando");

		if(Time.timeScale == 1){

			Time.timeScale = 0;
			print ("Pausando");

		}else if(Time.timeScale != 1){

			Time.timeScale = 1;
			print ("Despausando");

		}

	}

	public static void GameOver(){

		gameOver = true;
		print ("El juego ha terminado");

	}

	public static void GameWon(){

		gameWon = true;
		print ("Enhorabuena, sigues teniendo una esposa...");

	}

	public static void Exit(){

		Application.Quit ();

	}

}

