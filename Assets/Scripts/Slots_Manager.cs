using UnityEngine;
using System.Collections;

public class Slots_Manager : MonoBehaviour {

	// -------------------- Properties --------------

	[SerializeField] private static Sprite[] slots;
	private static bool[] slotsFilled;
	private static int freePlace;

	private enum cardTypes{

		Place, Happening, Reaction

	}

	// -------------------- Init --------------------

	void Start(){

		slots = new Sprite[3];
		freePlace = 0; 

	}

	// Asigna la imagen a la casilla disponible.

	public void AssignSlot(Card card){

		slots[freePlace] = card.getImage();
		if(CheckSlots() == true) ;

	}

	// Comprueba que sigue habiendo slots disponibles.

	public bool CheckSlots(){
		
		for(int i = 0; i < slotsFilled.Length; i++){
			
			if(slotsFilled[i] == false) return false;
			
		}
		
		return true;
		
	}

	// Reinicia los slots para la siguiente ronda. 

	public void ResetSlots(){

		freePlace = 0;

	}

}
