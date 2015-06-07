using UnityEngine;
using System.Collections;

public class GenerateIndexes : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void test(){
		int[] nonRepeatedArray = generateIndexes(7, "eve");
		for (int i = 0; i < nonRepeatedArray.Length; i++) {
			print (nonRepeatedArray[i]);
		}
	}
	
	private static bool hasDuplicates(int[] array) {
		bool found = false;
		for (int i = 0; i < array.Length; i++) {
			for (int j = 0; j < i; j++){
				if (array[i] == array[j]) {
					return true;
				}
			}
		}
		return found;
	}
	
	public static int[] generateIndexes(int size, string CardType){
		int[] result = null;
		if (CardType == "eve") {
			result = new int[3];
		} else if (CardType == "con" || CardType == "loc") {
			result = new int[2];
		} else {
			result = new int[7];
		}

		for (int i = 0; i < result.Length; i++) {
			result [i] = Random.Range (0, size);
			
		}
		
		if(hasDuplicates(result)){
			result = generateIndexes(size, CardType);
		}
		
		return result;
	}
}
