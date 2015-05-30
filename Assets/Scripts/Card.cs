using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	private static string[] cardTypeDefault = { "eve", "loc", "con" }; // Event, location, consecuence.

	// ----------------- Properties

	[SerializeField] private Sprite cardImage;
	private int idCard;
	private CardLogic card;
	[SerializeField]private Database cardBase;

	void Awake(){

		//cardBase = GameObject.FindWithTag("Database").GetComponent<Database>();

	}

	 // --------------- Getters y Setters

	public void setImage(Sprite img){

		cardImage = img;

	}

	public Sprite getImage (){

		return cardImage;

	}

	public void setCard(CardLogic nCard){
		
		card = nCard;
		
	}
	
	public CardLogic getCard (){
		
		return card;
		
	}

	public void setID(int nID){
		
		idCard = nID;
		
	}
	
	public int getID (){
		
		return idCard;
		
	}

	public string getType(){

		return card.getType ();

	}

	public void getEventCard(){

		card = cardBase.events[Random.Range (0, 6)];
		idCard = card.getID ();
		// Buscar recursos de imagen.

	}

	public void getLocationCard(){

		setCard (cardBase.locations[Random.Range (0, 6)]);
		setID(card.getID ());
		// Buscar recursos de imagen.

	}
	
	public void getConsecuenceCard(){

		setCard (cardBase.consecuences[Random.Range (0, 6)]);
		setID(card.getID ());
		// Buscar recursos de imagen.

	}

}
