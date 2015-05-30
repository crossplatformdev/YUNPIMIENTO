using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	// --------------------- Atributos ----------------

	[SerializeField] private bool sequenceSlot;
	[SerializeField] private Image HUDImage;
	[SerializeField] private Card currentCard;
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

			UpdateImage ();
			slotButton = GetComponent<Button> ();

		}

	}

	public void disableButton(){

		slotButton.enabled = false;
		HUDImage.enabled = false;

	}

	public void enableButton(){
		
		slotButton.enabled = false;
		HUDImage.enabled = false;
		
	}

	// --------------------- Getters y Setters ---------

	public void setCard(Card card){

		currentCard = card;
		UpdateImage ();

	}

	public void setType(slotTypes nTypes){

		type = nTypes;

	}

	public Card getCard(){

		return currentCard;

	}

	public slotTypes getPositionTypes(){

		return type;

	}


	// ----------------------- Metodos y Funcionalidad --

	public bool HaveCard(){

		if(currentCard != null) return true;
		else return false;

	}

	public void UpdateImage(){

		cardImage = currentCard.getImage();
		HUDImage.sprite = cardImage;
		HUDImage.material = null;

	}

	public void ResetCard(){

		if(HUDImage.sprite != null) cardImage = HUDImage.sprite;
		currentCard = null;
		HUDImage.sprite = HUDdefault;

	}

	public void Disable(){

	

	}

	public void Enable(){
		

		
	}


}
