using UnityEngine;
using System.Collections;



public class CardLogic {

	// ----------------- Properties

	private string cardName;
	private int id;
	
	public int[] puntPrevias;
	public int[] puntPosteriores;
	
	private int TOTAL_CARTAS = 7;
	
	private string type;

	public CardLogic(){
		
	}

	[SerializeField]private Database cardBase;
	
	void Awake(){
		
		cardBase = GameObject.FindWithTag("Database").GetComponent<Database>();

	}
	
	public CardLogic(string type, int id, string cardName){
		this.type = type;
		this.id = id;
		this.cardName = cardName;
		if (type == "eve"){
			puntPrevias = new int[TOTAL_CARTAS*2];
			puntPosteriores = new int[TOTAL_CARTAS*2];
		}
		
	}
	 // --------------- Getters y Setters

	
	public void SetPuntPrevia(int pos, int punt){
		puntPrevias[pos] = punt;
	}
	
	public void SetPuntPosterior(int pos, int punt){
		puntPosteriores[pos] = punt;
	}

	public string getType(){

		return type;

	}

	public int getID(){

		return id;

	}

}
