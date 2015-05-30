using UnityEngine;
using System.Collections;
using System;

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

	// Cartas.

	GameObject EveCard;
	GameObject EveCard2;
	GameObject EveCard3;

	

	Card myEveCard;
	Card myEveCard2;
	Card myEveCard3;
	
	GameObject LocCard;
	GameObject LocCard2;

	Card myLocCard;
	Card myLocCard2;
	
	GameObject ConCard;
	GameObject ConCard2;
	
	Card myConCard;
	Card myConCard2;

	public GameObject fader;
	Fader fader2;

	// -------------------- Elementos de la Escena -----------

	[SerializeField] private Wife theWife;
	[SerializeField] private Slots_Manager slotManager;


	// --------------------- Inicializacion ------------------

	void Awake(){

		gameOver = false;
		gameWon = false;
		handCards = new Card[7];
		enableControl = false;
		theWife.setAffinity(25);
<<<<<<< HEAD
		fader2 = fader.GetComponentInChildren<Fader>();
=======
>>>>>>> origin/master
		BuildDeck();
	

	}

	void Start(){


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

		day++;

		if(gameOver == false)slotManager.ResetSlots();

		//ShuffleDeck();

		slotManager.BuildHand(handCards);

		enableControl = true;

	}

	public void CheckRound(){ // Actualizar para implementar los calculos. 


		if(slotManager.CheckSlots() == false){

			int result = 0;

			result = slotManager.CheckSequence();

			//theWife.UpdateAffinity(result);
			theWife.UpdateAffinity(result);

			if(theWife.CheckAffinityStatus() == -1) GameOver();
			else if (theWife.CheckAffinityStatus () == 1) GameWon ();

			NewRound ();

		}

	}

	public void BuildDeck(){

		EveCard = GameObject.Instantiate (cardPref) as GameObject;
		myEveCard = EveCard.GetComponent<Card>();
		EveCard2 = GameObject.Instantiate (cardPref) as GameObject;
		myEveCard2 = EveCard.GetComponent<Card>();
		EveCard3 = GameObject.Instantiate (cardPref) as GameObject;
		myEveCard3 = EveCard.GetComponent<Card>();

		LocCard = GameObject.Instantiate (cardPref) as GameObject;
		myLocCard = EveCard.GetComponent<Card>();
		LocCard2 = GameObject.Instantiate (cardPref) as GameObject;
		myLocCard2 = EveCard.GetComponent<Card>();

		ConCard = GameObject.Instantiate (cardPref) as GameObject;
		myConCard = EveCard.GetComponent<Card>();
		ConCard2 = GameObject.Instantiate (cardPref) as GameObject;
		myConCard2 = EveCard.GetComponent<Card>();
		ShuffleDeck ();


	}
	
	public void ShuffleDeck(){

		

		
		myEveCard.getEventCard();
		
	/*	do{
			myEveCard2.getEventCard();
		}while (myEveCard2.getID() == myEveCard.getID());
		
		do{
			myEveCard3.getEventCard();
		}while (myEveCard3.getID() == myEveCard.getID() || myEveCard3.getID() == myEveCard2.getID());
	*/	
	

		myEveCard2.getEventCard();
		myEveCard3.getEventCard();


		myLocCard.getLocationCard();
	
	/*	do{
			myLocCard2.getLocationCard();
		}while (myLocCard2.getID() == myLocCard.getID());
	*/
		myLocCard2.getLocationCard();

		
		myConCard.getConsecuenceCard();

	/*	do{
			myConCard2.getConsecuenceCard();
		}while (myConCard2.getID() == myConCard.getID());
		
*/
		myConCard.getConsecuenceCard();

		handCards[0] = myEveCard;
		handCards[1] = myEveCard2;
		handCards[2] = myEveCard3;


		handCards[3] = myLocCard;
		handCards[4] = myLocCard2;

		handCards[5] = myConCard;
		handCards[6] = myConCard2;
		
		handCards = Shuffle(handCards);
		handCards = Shuffle(handCards);
		//handCards = Shuffle(handCards);
		//handCards = Shuffle(handCards);
		//handCards = Shuffle(handCards);
	//	handCards = Shuffle(handCards);



	}



	public void CinematicScene(){

		StartCoroutine ("FadeScene");
		// FOTOS INTERMEDIAS, TEXTO, PAUSA, PULSE PARA CONTINUAR, TRANSICION,...

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
	
	public Card[] ShuffleX(int i, Card[] deck){
		for (int x = 0; x<i; x++){
			deck = Shuffle (deck);
		}
		return deck;
	}
	
	
	public Card[] Shuffle(Card[] deck){  

		System.Random r = new System.Random(DateTime.Now.Millisecond);
		Card temp;
		int randomNumber;
		int count = deck.Length;
		for (int index = count -1; index > 0; index--){
			randomNumber = r.Next(0, index+1);
			temp = deck [index];
			deck[index] = deck[randomNumber];
			deck[randomNumber] = temp;
		}	
		return deck;	
	}
		

}

