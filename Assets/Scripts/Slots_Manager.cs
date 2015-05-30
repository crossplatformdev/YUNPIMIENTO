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

	public void AssignSlot(Slot slot){

		// Comprueba que la casilla no tenga carta, y entonces se la asigna, marca la casilla como ocupada, y aumenta el contador.

		//if(!seqSlots[freePlace].HaveCard()){

		//if(Game_Master.GMinstance.getControlStatus() == true){
		
		seqSlots[freePlace].setCard (slot.getCard());
		seqSlots[freePlace].UpdateImage();
		slotsFilled[freePlace] = true;
		freePlace++;
		print("Asignando carta " + freePlace);

		Game_Master.GMinstance.CheckRound ();

	//	}

		//}

	}

	public void BuildHand(CardLogic[] hand){
		
		for(int i =0; i < handSlots.Length; i++){

			handSlots[i].setCard (hand[i]);
			print ("metiendo cartas " + i);

		}
			
	}

	// Comprueba que sigue habiendo slots disponibles.

	public bool CheckSlots(){
		
		for(int i = 0; i < slotsFilled.Length; i++){
			
			if(slotsFilled[i] == false) return true;
			
		}
		
		return false;
		
	}

	public int CheckSequence(){

		int result = 0;
	
		if(seqSlots[1].getCard().getType() != "eve"){

			result = -7;

			print (" resultado " + result + " de la carta " + seqSlots[1].getCard().getID());

			return result;

		}else{

			int prevID = seqSlots[0].getCard().getID ();
			int nextID = seqSlots[2].getCard().getID ();
				CardLogic midCard = seqSlots[1].getCard ().getCard ();

			for (int i = 0; i < 14; i++){

					if(i == prevID - 1){

					result += midCard.puntPrevias[i-1];

				}

			}

			for (int i = 0; i < 14; i++){
				
				if(i == nextID - 1){
					
					result += midCard.puntPosteriores[i-1];
					
				}
				
			}

			print (" resultado " + result + " de la carta " + seqSlots[1].getCard().getID());

			return result;

		} 

	}


	// Reinicia los slots para la siguiente ronda. 

	public void ResetSlots(){

		freePlace = 0;

		for(int i = 0; i < seqSlots.Length; i++){

			seqSlots[i].ResetCard();
			slotsFilled[i] = false;

		}

		for (int i = 0; i < handSlots.Length; i++){

			handSlots[i].enableButton();
			print ("Rehabilitando " + i);

		}

	}

}
