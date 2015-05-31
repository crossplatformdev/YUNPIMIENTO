﻿using UnityEngine;
using System.Collections;
using System;

public class Game_Master : MonoBehaviour {

	public Sprite[] eventImages;
	public Sprite[] locationImages;
	public Sprite[] consecuencesImages;

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

	private int day;

	public CardLogic[] slotCards = new CardLogic[3];

	public CardLogic[] handCards = new CardLogic[7];// robo de cartas.

	private bool enableControl;

	private GameObject cardPref;

	private GameObject cardBase;

	public Cinematic myCinematics;

	// -------------------- Elementos de la Escena -----------

	[SerializeField] private Wife theWife;
	public Slots_Manager slotManager;


	// --------------------- Inicializacion ------------------

	void Awake(){

		gameOver = false;
		gameWon = false;
		enableControl = false;
		theWife.setAffinity(25);
		myCinematics = GetComponent<Cinematic>();
		day = 1;

	}

	void Start(){

		ShuffleDeck ();
		
	}

	// ------------------- Getters y Setters -------------------

	public Wife getWife(){

		return theWife;

	}

	public bool getWinState(){

		return gameWon;

	}

	public bool getOverState(){
		
		return gameOver;
		
	}

	// ------------------ Gestion de Rondas



	// Gestiona todo el resultado del turno, una vez que se ha completado la sentencia o combinacion de cartas.
	// Cada vez que se asigna una carta, Slot_Manager lanza una comprobacion de ronda. 

	public void NewRound(){

		//CinematicScene ();

		day++;

		if(gameOver == false)slotManager.ResetSlots();

		//ShuffleDeck();

		enableControl = true;

	}

	public void CheckRound(){ // Actualizar para implementar los calculos. 


		if(slotManager.CheckSlots() == false){

			int result = 0;

			result = slotManager.CheckSequence();


			theWife.UpdateAffinity(result);

			if(theWife.CheckAffinityStatus() == -1) GameOver();
			else if (theWife.CheckAffinityStatus () == 1) GameWon ();
			else{
				for (int i = 0; i < slotManager.handSlots.Length; i++){
					slotManager.handSlots[i].disableButton(10);
				}
				//NewRound ();
				CinematicScene ();
			}

		}

	}


	
	
	public void CinematicScene(){
		
		myCinematics.Transition (day);
		
	}

	public void ShuffleDeck(){

		cardBase = (GameObject)GameObject.FindWithTag("Database");

		int[] randNot = new int[3];

		int rand = RandomNums (randNot);

		randNot[0] = rand;

		handCards[0] = cardBase.GetComponent<Database>().events[rand];
		slotManager.UpdateSlots("eve", 0, handCards[0].getID()-1); 

		rand = RandomNums (randNot);
		
		randNot[1] = rand;


		print (" handCards " + handCards[0].getType() + " " + handCards[0].getID ()); 
		handCards[1] = cardBase.GetComponent<Database>().events[rand];
		slotManager.UpdateSlots("eve", 1, handCards[1].getID()-1);

		rand = RandomNums (randNot);
		
		randNot[2] = rand;


		handCards[2] = cardBase.GetComponent<Database>().events[rand];
		slotManager.UpdateSlots("eve", 2, handCards[2].getID()-1); 


		handCards[3] = cardBase.GetComponent<Database>().locations[rand];
		slotManager.UpdateSlots("loc", 3, handCards[3].getID()-1); 

		randNot = new int[3];
		
		rand = RandomNums (randNot);
		
		randNot[0] = rand;

		handCards[4] = cardBase.GetComponent<Database>().locations[rand];
		slotManager.UpdateSlots("loc", 4, handCards[4].getID()-1); 

		handCards[5] = cardBase.GetComponent<Database>().consecuences[rand];
		slotManager.UpdateSlots("con", 5, handCards[5].getID()-1); 

		randNot = new int[3];
		
		rand = RandomNums (randNot);
		
		randNot[0] = rand;

		handCards[6] = cardBase.GetComponent<Database>().consecuences[rand];
		slotManager.UpdateSlots("con", 6, handCards[6].getID()-1); 

		
		//handCards = Shuffle(handCards);
	//	handCards = Shuffle(handCards);
		//handCards = Shuffle(handCards);
		//handCards = Shuffle(handCards);
		//handCards = Shuffle(handCards);
	//	handCards = Shuffle(handCards);

		print (" Estoy asignandooooo");

	}


	public int RandomNums(int[] gotNums){

		int rand = UnityEngine.Random.Range (0,7);

		while(isIN(rand, gotNums)){

			rand = UnityEngine.Random.Range (0,7);

		}

		return UnityEngine.Random.Range (0,7);

	}

	public bool isIN(int nRand, int [] nums){

		for(int i = 0; i < nums.Length-1; i++){

			if(nRand == nums [i]) return true;

		}

		return false;

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

		Application.LoadLevel("Dummy_1");

			break;

		}

	}

	public void GameOver(){

		gameOver = true;
		myCinematics.LostScreen();

		print ("El juego ha terminado");

	}

	public void GameWon(){

		gameWon = true;
		myCinematics.WonScreen();
		print ("Enhorabuena, sigues teniendo una esposa...");

	}

	public void Exit(){

		Application.Quit ();

	}
	
	public CardLogic[] ShuffleX(int i, CardLogic[] deck){
		for (int x = 0; x<i; x++){
			deck = Shuffle (deck);
		}
		return deck;
	}
	
	
	public CardLogic[] Shuffle(CardLogic[] deck){  

		System.Random r = new System.Random(DateTime.Now.Millisecond);
		CardLogic temp;
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
		

	public int[] ShuffleBag(int cant){

		int[] tempNum = new int[cant];

		for (int i = 0; i < tempNum.Length; i++){

			tempNum[i] = i;

		}

		// swapper

		int num;
		int rand;

		for(int i = 0; i < 12; i++){

			rand = UnityEngine.Random.Range (0, 7);
			 
			num = tempNum[rand];

			if(rand+1 > tempNum.Length-1){

				tempNum[rand] = tempNum[rand-1];
				tempNum[rand-1] = rand;

			}else{ 

				tempNum[rand] = tempNum[rand+1];
				tempNum[rand+1] = rand;

			}

		}

		return tempNum;

	}

}

