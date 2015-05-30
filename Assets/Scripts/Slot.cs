using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	// --------------------- Atributos ----------------

	[SerializeField] private bool sequenceSlot;
	[SerializeField] private Image HUDImage;
	[SerializeField] private Card currentCard;
	private Material HUDMat;
	private Sprite cardImage;

	public enum slotTypes{ // Esto esta por determinar.
		
		Previous, Midle, Next
		
	}
		
	slotTypes type;

	// --------------------- Init --------------------

	void Start(){

		HUDImage = this.GetComponent<Image>();
		HUDMat = HUDImage.material;
		if(sequenceSlot != true)UpdateImage ();

	}

	// --------------------- Getters y Setters ---------

	public void setCard(Card card){

		currentCard = card;

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
		HUDImage.material = HUDMat;

	}



}
