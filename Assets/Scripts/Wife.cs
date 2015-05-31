using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wife : MonoBehaviour {

	// Properties

	public Slider affinityBar;
	[SerializeField] private int maxAffinity;
	private int startValue;
	private float affinity;



	void Start(){

		if(maxAffinity <= 10) setAffinity(maxAffinity = 50);
		affinity = startValue;

	}

	// ------ Getters & Setters


	public void setAffinity(float nAffinity){

		affinity = nAffinity;
		affinityBar.maxValue = maxAffinity;
		startValue = maxAffinity/2;
		affinityBar.value = startValue;
	}

	public float getAffinity(){

		return affinity;

	}

	public void UpdateAffinity(float nAffinity){
	
		//affintyBar.value += Mathf.MoveTowards(0, nAffinity, 0.1f);
		if(affinityBar.value + nAffinity > maxAffinity){

			affinityBar.value = maxAffinity;
			print (affinityBar.value);
			affinity = maxAffinity;
			print ("La afinidad ha cambiado a " + affinity);

		}else{

			affinityBar.value += nAffinity;
			print (affinityBar.value);
			affinity += nAffinity;
			print ("La afinidad ha cambiado a " + affinity);

		}
	}

	public int CheckAffinityStatus(){

		if(affinity <= 0){

			return -1;

		}else if (affinity >= maxAffinity){

			return 1;

		}else return 0;

	}
}
