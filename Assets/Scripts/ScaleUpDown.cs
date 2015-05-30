using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScaleUpDown : MonoBehaviour {
	
	RectTransform cardCon;
	int cont = 0;
	bool scaleUp;
	RectTransform original;
	// Use this for initialization
	void Start () {
		cardCon = GetComponent<RectTransform>();
		original = cardCon;
	//	this.GetComponentInParent<HandController>().lockedScale = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (scaleUp){ 
			cont++;
			if (cont <= 30) cardCon.localScale += new Vector3(0.04f, 0.06f, 0.04f);
		}//else transform.localScale = original.localScale;
	}
	
	
	void OnMouseEnter(){

			cardCon.position = new Vector3(transform.position.x,transform.position.y, transform.position.z * (float)(1d/10d));
			scaleUp = true;

	}
	
	void OnMouseExit(){
		
		cardCon.position = new Vector3(transform.position.x,transform.position.y, transform.position.z * (float)(11d/ 10d));
			cardCon.localScale = new Vector3 (1, 1.5f, 1);
			scaleUp = false;
			cont = 0;
	
	}
}
