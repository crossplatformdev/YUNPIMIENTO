using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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

	public Timer drunkClock; // ---------------------- TIMER!!!!!!!!!!!!!!!!!!

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
		day = 2;

	}

	void Start(){

		ShuffleDeck ();
		GameObject.FindWithTag("SoundMgr").GetComponent<SoundMgr>().PlayIntro();
		drunkClock.launchTimer();
		
	}



	void Update(){
		if(Input.GetKeyDown("escape")){
			Application.LoadLevel (0);
		}

		
		if( drunkClock.timerPassed()){

			for(int i = 0; i < 3; i++){
				
				if(!slotManager.slotsFilled[i])slotManager.AssignSlot (UnityEngine.Random.Range (0, 7));
				
				// GenerateIndexes.generateIndexes(3, null);
	
			}
		}


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

	public void ResetTimer(){

		drunkClock.ResetTimer();

	}

	public void NewRound(){
	
		day++;
		drunkClock.launchTimer(10); 
		
		enableControl = true;

		//if(gameOver == false)slotManager.ResetSlots();
		//ShuffleDeck();
		//CinematicScene ();
	}

	public void CheckRound(){ // Actualizar para implementar los calculos. 


		if(slotManager.CheckSlots() == false){

			drunkClock.roundWasSuccesful();  // ---------------------- TIMER!!!!!!!!!!!!!!!!!!


			float result = 0;

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

		int[] dispersion = GenerateIndexes.generateIndexes(7, "dispersion");
		/*dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);
		dispersion = Shuffle(dispersion);*/
		dispersion = Shuffle(dispersion);
		
		cardBase = (GameObject)GameObject.FindWithTag("Database");

		int[] eveArray = GenerateIndexes.generateIndexes(7, "eve");//new int[3];

		//int rand = RandomNums (randNot);

		//randNot[0] = rand;

		handCards[dispersion[0]] = cardBase.GetComponent<Database>().events[eveArray[0]];
		slotManager.UpdateSlots("eve", dispersion[0], handCards[dispersion[0]].getID()-1); 

		//rand = RandomNums (randNot);
		
		//randNot[1] = rand;


		//print (" handCards " + handCards[0].getType() + " " + handCards[0].getID ()); 
		handCards[dispersion[1]] = cardBase.GetComponent<Database>().events[eveArray[1]];
		slotManager.UpdateSlots("eve", dispersion[1], handCards[dispersion[1]].getID()-1);

		//rand = RandomNums (randNot);
		
		//eveArray[2] = rand;


		handCards[dispersion[2]] = cardBase.GetComponent<Database>().events[eveArray[2]];
		slotManager.UpdateSlots("eve", dispersion[2], handCards[dispersion[2]].getID()-1); 

		int[] locArray = GenerateIndexes.generateIndexes(7, "loc");//new int[3];
		
		handCards[dispersion[3]] = cardBase.GetComponent<Database>().locations[locArray[0]];
		slotManager.UpdateSlots("loc", dispersion[3], handCards[dispersion[3]].getID()-1); 

		//randNot = new int[3];
		
		//rand = RandomNums (randNot);
		
		//randNot[0] = rand;

		handCards[dispersion[4]] = cardBase.GetComponent<Database>().locations[locArray[1]];
		slotManager.UpdateSlots("loc", dispersion[4], handCards[dispersion[4]].getID()-1); 
		
		int[] conArray = GenerateIndexes.generateIndexes(7, "con");//new int[3];
		
		handCards[dispersion[5]] = cardBase.GetComponent<Database>().consecuences[conArray[0]];
		slotManager.UpdateSlots("con", dispersion[5], handCards[dispersion[5]].getID()-1); 

		//randNot = new int[3];
		
		//rand = RandomNums (randNot);
		
		//randNot[0] = rand;
		
		handCards[dispersion[6]] = cardBase.GetComponent<Database>().consecuences[conArray[1]];
		slotManager.UpdateSlots("con", dispersion[6], handCards[dispersion[6]].getID()-1); 

		
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
			
			Application.LoadLevel("StartMenu");
			break;

		case 2:

			Application.LoadLevel("Game");

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
	
	public int[] Shuffle(int[] deck){  
		
		System.Random r = new System.Random(DateTime.Now.Millisecond);
		int temp;
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

