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

	void Start(){

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

	public void BuildHand(Card[] hand){
		
		for(int i =0; i < handSlots.Length; i++){

			handSlots[i].setCard (hand[i]);

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

		int result;
	
	//	if
	//	result = events.getValue(seqSlots[0].getCard () );
	//	result += events.getValue(seqSlots[0].getCard () );

		return 0; // IMPLEMENTARRRRR!!!!!!

	}


	// Reinicia los slots para la siguiente ronda. 

	public void ResetSlots(){

		freePlace = 0;

		for(int i = 0; i < seqSlots.Length; i++){

			seqSlots[i].ResetCard();
			slotsFilled[i] = false;

		}

	}

}
