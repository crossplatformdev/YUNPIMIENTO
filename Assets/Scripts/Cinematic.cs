using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cinematic : MonoBehaviour {

	public CanvasGroup imgCanvas;
	public Image imgFade;
	public Text textBox;
	public Camera secuenceCam;
	public Camera mainCam;

	public Sprite WinScreen;
	public Sprite LoseScreen;
	
	public void Transition(int day){

		if(Game_Master.GMinstance.getWinState() == false && Game_Master.GMinstance.getOverState() == false){


			StartCoroutine ("Fading");

			secuenceCam.enabled = true;
			mainCam.enabled = false;

			textBox.text = "Day " + day + "... ";

			imgFade.CrossFadeAlpha(1.0f, 3.0f, false);


			//secuenceCam.enabled = false;
			//mainCam.enabled = true;

		}

	}

	IEnumerator Fading(){

		for(float i = 0.0f; i < 1.0f; i += 0.05f){
			
			imgCanvas.alpha = 0.0f;
			imgCanvas.alpha += 0.05f;
			yield return null;
		}

	}

	public void WonScreen(){

		secuenceCam.enabled = true;
		mainCam.enabled = false;
		
		// Fade.

		print ("Estoy llamando a WonScreen");

		textBox.text = "";
		imgFade.color = Color.white;
		imgFade.sprite = WinScreen;
		
		// Fade.
		
		//secuenceCam.enabled = false; mainCam.enabled = true;

	}

	public void LostScreen(){

		secuenceCam.enabled = true;
		mainCam.enabled = false;
		
		// Fade.

		print ("Estoy llamando a LostScreen");

		textBox.text = "";
		imgFade.color = Color.white;
		imgFade.sprite = LoseScreen;
		
		// Fade.
		
		//secuenceCam.enabled = false; mainCam.enabled = true;

	}

}
