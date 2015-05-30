using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	// --------------------- Atributos ----------------

	[SerializeField] private bool sequenceSlot;
	[SerializeField] private Image HUDImage;
	[SerializeField] private CardLogic currentCard;
	private Sprite HUDdefault;
	private Sprite cardImage;

	private Button slotButton;

	public enum slotTypes{ // Esto esta por determinar.
		
		Previous, Midle, Next
		
	}
		
	slotTypes type;

	// --------------------- Init --------------------

	void Awake(){

		HUDImage = this.GetComponent<Image>();
		HUDdefault = HUDImage.sprite;

		if(sequenceSlot != true){

			//UpdateImage ();
			slotButton = GetComponent<Button> ();

		}

	}

	public void disableButton(){

		slotButton.enabled = false;
		HUDImage.enabled = false;

	}

	public void enableButton(){
		
		slotButton.enabled = true;
		HUDImage.enabled = true;
		
	}

	// --------------------- Getters y Setters ---------

	public void setCard(CardLogic card){

		currentCard = card;
		//UpdateImage ();

	}

	public void setType(slotTypes nTypes){

		type = nTypes;

	}

	public CardLogic getCard(){

		return currentCard;

	}

	public slotTypes getPositionTypes(){

		return type;

	}


	// ----------------------- Metodos y Funcionalidad --
	

	public void UpdateImage(int op, int pos){

		if(op == 0){

			cardImage = Game_Master.GMinstance.eventImages[Game_Master.GMinstance.slotCards[pos].getID()-1];
	
		}

		if(op == 1){

			cardImage = Game_Master.GMinstance.locationImages[Game_Master.GMinstance.slotCards[pos].getID()-1];
		
		}

		if(op == 2){
			
			cardImage = 	cardImage = Game_Master.GMinstance.consecuencesImages[Game_Master.GMinstance.slotCards[pos].getID()-1];
			
		}

		HUDImage.sprite = cardImage;
		HUDImage.material = null;

	}

	public void newImage(Sprite img){

		cardImage = img;
		HUDImage.sprite = cardImage;

	}

	public void ResetCard(){

		if(HUDImage.sprite != null) cardImage = HUDImage.sprite;
		currentCard = null;
		HUDImage.sprite = HUDdefault;

	}

	public void Disable(){

		

	}

	public void Enable(){
			
		slotButton.enabled = true;
		HUDImage.enabled = true;
				
	}


}
