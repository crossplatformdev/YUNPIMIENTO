
using UnityEngine;
using System.Collections;

public class Slots_Manager : MonoBehaviour {


	// ----------------------- Singleton ---------------------
	
	private static Game_Master _SlotMinstance;
	
	public static Game_Master SlotMinstance{
		
		get{
			
			if(_SlotMinstance == null)
				_SlotMinstance = GameObject.FindObjectOfType<Game_Master>();
			
			return SlotMinstance;
			
		}
		
	}

	// -------------------- Properties --------------

	[SerializeField] private Slot[] seqSlots;
	[SerializeField] private Slot[] handSlots;
	private bool[] slotsFilled;
	private int freePlace;
	
	// -------------------- Init --------------------

	void Awake(){

		freePlace = 0; 
		slotsFilled = new bool[seqSlots.Length];
		InitSlots ();

	}



	public void InitSlots(){

		seqSlots[0].setType(Slot.slotTypes.Previous);
		seqSlots[1].setType(Slot.slotTypes.Midle);
		seqSlots[2].setType(Slot.slotTypes.Next);	

	}

	// Asigna la imagen a la casilla disponible.

	public void AssignSlot(int pos){

		// Comprueba que la casilla no tenga carta, y entonces se la asigna, marca la casilla como ocupada, y aumenta el contador.

		Game_Master.GMinstance.slotCards[freePlace] = Game_Master.GMinstance.handCards[pos] ;

		if(Game_Master.GMinstance.slotCards[freePlace].getType() == "eve"){

			seqSlots[freePlace].UpdateImage (0,freePlace);

		}

		if (Game_Master.GMinstance.slotCards[freePlace].getType() == "loc"){

			seqSlots[freePlace].UpdateImage (1,freePlace);

		}

		if (Game_Master.GMinstance.slotCards[freePlace].getType() == "con"){
			
			seqSlots[freePlace].UpdateImage (2,freePlace);
			
		}

		slotsFilled[freePlace] = true;
		freePlace++;
		print("Asignando carta " + freePlace);

		Game_Master.GMinstance.CheckRound ();

	}


	// Comprueba que sigue habiendo slots disponibles.

	public bool CheckSlots(){
		
		for(int i = 0; i < slotsFilled.Length; i++){
			
			if(slotsFilled[i] == false) return true;
			
		}
		
		return false;
		
	}

	public int CheckSequence(){ // Combinaciones de evento -3

		int result = 0;

		Debug.Log (Game_Master.GMinstance.slotCards[1]);

		if(Game_Master.GMinstance.slotCards[1].getType().CompareTo("eve") != 0){

			result = -7;

			return result;

		}else{


			int nextID = Game_Master.GMinstance.slotCards[2].getID ();

			if(Game_Master.GMinstance.slotCards[0].getType().CompareTo("eve") == 0){

				result += -3;

			}else{

				int prevID = Game_Master.GMinstance.slotCards[0].getID ();

				int i = 0;
			
					for (i = 0; i < 14; i++){

						if(i == prevID - 1){

						if(Game_Master.GMinstance.slotCards[0].getType().CompareTo("con") == 0) result += Game_Master.GMinstance.slotCards[1].puntPrevias[i+7];
						else result += Game_Master.GMinstance.slotCards[1].puntPrevias[i];

						}

					}

			}

			if(Game_Master.GMinstance.slotCards[2].getType().CompareTo("eve") == 0){
				
				result += -3;
				
			}else{

				int i = 0;

			

			for (i = 0; i < 14; i++){
				
				if(i == nextID - 1){
					
					if(Game_Master.GMinstance.slotCards[0].getType().CompareTo("con") == 0) result += Game_Master.GMinstance.slotCards[1].puntPosteriores[i+7];
					else result += Game_Master.GMinstance.slotCards[1].puntPosteriores[i];
					
				}
				
			}

			print (" resultado " + result + " de la carta");

			

			} 

			return result;

		}

	}


	public void UpdateSlots(string type,int pos, int imgVal){

		if(type.CompareTo("eve") == 0){

			handSlots[pos].newImage (Game_Master.GMinstance.eventImages[imgVal]);

		}

		if(type.CompareTo("loc") == 0){
			
			handSlots[pos].newImage (Game_Master.GMinstance.locationImages[imgVal]);
			
		}

		if(type.CompareTo("con") == 0){
			
			handSlots[pos].newImage (Game_Master.GMinstance.consecuencesImages[imgVal]);
			
		}

	}


	// Reinicia los slots para la siguiente ronda. 

	public void ResetSlots(){

		freePlace = 0;

		for(int i = 0; i < 3 ; i++){

			Game_Master.GMinstance.slotCards[i] = null;
			slotsFilled[i] = false;

		}

		for (int i = 0; i < 7; i++){

			handSlots[i].enableButton();
			print ("Rehabilitando " + i);

		}

	}

}
