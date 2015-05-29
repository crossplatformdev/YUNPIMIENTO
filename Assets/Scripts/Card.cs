using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	// ----------------- Properties

	private Sprite cardImage;
	private string cardName;

	[SerializeField] Sprite slotSprite;

	// ----------------- Init 

	void Start(){



	}
	 // --------------- Getters y Setters

	public void setImage(Sprite img){

		cardImage = img;

	}

	public Sprite getImage (){

		return cardImage;

	}

	void OnClick(){

		slotSprite = cardImage;

	}

}
