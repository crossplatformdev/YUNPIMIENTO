using UnityEngine;
using System.Collections;

public class CompareCards : MonoBehaviour {
	public static CardLogic[] acomparar = new CardLogic[7];
	// Use this for initialization
	void Start () {
		test ();
	}

	void OnClick(){
		test()
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	public static void test(){
		for (int i = 0; i < 7; i++) {
			acomparar[i] = new CardLogic( "eve", i , "card"+i);
		}
		CardLogic[] testArray = compareCards (acomparar, 3);
		for (int i = 0; i < testArray.Length; i++) {
			print (testArray[i].getID());
		}
	}
	
	private static CardLogic[] compareCards(CardLogic[] acomparar, int size){
		CardLogic[] result = generateUniqueDeck(size, acomparar[0].getType());
		return result;
	}
	
	private static bool isDuplicate(CardLogic [] array) {
		bool found = false;
		for (int i = 0; i < array.Length; i++) {
			for (int j = 0; j < i; j++)
			if (array[i].getID() == array[j].getID()) {
				found = true;
				break;
			}
		}
		return found;
	}
	
	private static CardLogic[] generateUniqueDeck(int size, string type){
		CardLogic[] result = new CardLogic[size];
		if (acomparar [0].getType () == type) {
			for(int i = 0; i < size; i++){
				if(!isDuplicate(result)){
					result[i] = acomparar[Random.Range(0,7)];
				}
			}
		}
		return result;
	}
}
