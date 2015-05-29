using UnityEngine;
using System.Collections;

public class Wife : MonoBehaviour {

	// Properties

	private static int affinity;

	// ------ Getters & Setters


	public void setAffinity(int nAffinity){

		affinity = nAffinity;

	}

	public int getAffinity(){

		return affinity;

	}

	public void UpdateAffinity(int nAffinity){
	
		affinity += nAffinity;
		print ("La afinidad ha cambiado a " + affinity);

	}

	public void CheckAffinityStatus(){

		if(affinity <= 0){

			Game_Master.GMinstance.GameOver();

		}

	}
}
