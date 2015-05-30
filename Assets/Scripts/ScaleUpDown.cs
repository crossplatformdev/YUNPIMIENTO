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
			cardCon.position = new Vector3(cardCon.position.x, cardCon.position.y, -1);
			cont++;
			if (cont <= 20) cardCon.sizeDelta = cardCon.sizeDelta + new Vector2(2f, 2f);
		}//else transform.localScale = original.localScale;
	}
	
	
	void OnMouseEnter(){
			Debug.Log ("Entro!");
		//	cardCon.position = new Vector3(transform.position.x,transform.position.y, transform.position.z * (float)(1d/10d));
			scaleUp = true;

	}
	
	void OnMouseExit(){
			
		//cardCon.position = new Vector3(transform.position.x,transform.position.y, transform.position.z * (float)(11d/ 10d));
			cardCon.sizeDelta = new Vector2(1f,1f);
			cardCon.position = new Vector3(cardCon.position.x, cardCon.position.y, 0);
			scaleUp = false;
			cont = 0;
	
	}
}
