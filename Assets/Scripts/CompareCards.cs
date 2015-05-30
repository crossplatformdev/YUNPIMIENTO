using UnityEngine;
using System.Collections;

public class CompareCards : MonoBehaviour {
	public static CardLogic[] acomparar = new CardLogic[7];
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void test(){
		acomparar = new CardLogic[7];
		for (int i = 0; i < 7; i++) {
			acomparar[i] = new CardLogic( "eve", i , "card"+i);
		}
		CardLogic[] nonRepeatedArray = generateUniqueDeck (3, acomparar);
		for (int i = 0; i < nonRepeatedArray.Length; i++) {
			print (nonRepeatedArray[i].getID());
		}
	}

	private static bool hasDuplicates(CardLogic[] array) {
		bool found = false;
		for (int i = 0; i < array.Length; i++) {
			for (int j = 0; j < i; j++){
				if (array[i].getID() == array[j].getID()) {
					return true;
				}
			}
		}
		return found;
	}
	
	public static CardLogic[] generateUniqueDeck(int size, CardLogic[] acomparar){
		CardLogic[] result = new CardLogic[size];
		for (int i = 0; i < size; i++) {
			result [i] = acomparar [Random.Range (0, 7)];

		}

		if(hasDuplicates(result)){
			result = generateUniqueDeck(size, acomparar);
		}

		return result;
	}
}
