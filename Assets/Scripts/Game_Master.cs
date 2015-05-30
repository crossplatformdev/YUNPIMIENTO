using UnityEngine;
using System.Collections;

public class Game_Master : MonoBehaviour {

	// ----------------------- Singleton ---------------------

	private static Game_Master _GMinstance;

	public static Game_Master GMinstance{

		get{

			if(_GMinstance == null)
				_GMinstance = GameObject.FindObjectOfType<Game_Master>();

			return _GMinstance;

		}

	}

	// --------------------- Atributos -----------------------


	private bool gameOver;
	private bool gameWon;

	private int diffLevel; // nivel de dificultad

	private int totalRounds;
	private int roundNumber;

	private int day;

	private Card[] handCards; // robo de cartas.

	private bool enableControl;

	public GameObject cardPref;

	// -------------------- Elementos de la Escena -----------

	[SerializeField] private Wife theWife;
	[SerializeField] private Slots_Manager slotManager;


	// --------------------- Inicializacion ------------------

	void Start(){

		gameOver = false;
		gameWon = false;
		handCards = new Card[7];
		enableControl = false;
		theWife.setAffinity(25);

	}

	// ------------------- Getters y Setters -------------------

	public Wife getWife(){

		return theWife;

	}

	// ------------------ Gestion de Rondas



	// Gestiona todo el resultado del turno, una vez que se ha completado la sentencia o combinacion de cartas.
	// Cada vez que se asigna una carta, Slot_Manager lanza una comprobacion de ronda. 

	public void NewRound(){

		CinematicScene ();

		if(gameOver == false)slotManager.ResetSlots();
		ShuffleDeck();
		day++;

		enableControl = true;

	}

	public void CheckRound(){ // Actualizar para implementar los calculos. 


		if(slotManager.CheckSlots() == false){

			int result = 0;

			result = slotManager.CheckSequence();

			//theWife.UpdateAffinity(result);
			theWife.UpdateAffinity(10);

			if(theWife.CheckAffinityStatus() == -1) GameOver();
			else if (theWife.CheckAffinityStatus () == 1) GameWon ();

			NewRound ();

		}

	}
	
	public void ShuffleDeck(){


		GameObject EveCard = GameObject.Instantiate (cardPref) as GameObject;
		Card myEveCard = EveCard.GetComponent<Card>();
		GameObject EveCard2 = GameObject.Instantiate (cardPref) as GameObject;
		Card myEveCard2 = EveCard.GetComponent<Card>();
		GameObject EveCard3 = GameObject.Instantiate (cardPref) as GameObject;
		Card myEveCard3 = EveCard.GetComponent<Card>();

		myEveCard.getEventCard();
		myEveCard2.getEventCard();
		myEveCard3.getEventCard();


		GameObject LocCard = GameObject.Instantiate (cardPref) as GameObject;
		Card myLocCard = EveCard.GetComponent<Card>();
		GameObject LocCard2 = GameObject.Instantiate (cardPref) as GameObject;
		Card myLocCard2 = EveCard.GetComponent<Card>();

		myLocCard.getLocationCard();
		myLocCard2.getLocationCard();

		GameObject ConCard = GameObject.Instantiate (cardPref) as GameObject;
		Card myConCard = EveCard.GetComponent<Card>();
		GameObject ConCard2 = GameObject.Instantiate (cardPref) as GameObject;
		Card myConCard2 = EveCard.GetComponent<Card>();
		myConCard.getConsecuenceCard();
		myConCard2.getConsecuenceCard();

		handCards[0] = myEveCard;
		handCards[1] = myEveCard2;
		handCards[2] = myEveCard3;


		handCards[3] = myLocCard;
		handCards[4] = myLocCard2;

		handCards[5] = myConCard;
		handCards[6] = myConCard2;

		Debug.Log (handCards[1].getID());


	}

	public void CinematicScene(){



	}

	public void EnableControl(){

		enableControl = true;

	}

	public void DisableControl(){

		enableControl = false;

	}

	public bool getControlStatus(){

		return enableControl;

	}

	public void NextLevel(int lvl){

		switch(lvl){

		case 1:

			break;

		case 2:

		Application.LoadLevel("Prototipo1");

			break;

		}

	}

	public void GameOver(){

		gameOver = true;
		print ("El juego ha terminado");

	}

	public void GameWon(){

		gameWon = true;
		print ("Enhorabuena, sigues teniendo una esposa...");

	}

	public void Exit(){

		Application.Quit ();

	}

}

