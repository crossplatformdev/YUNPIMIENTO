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

			
			secuenceCam.enabled = true;
			imgCanvas.alpha = 0.0f;
			textBox.text = "Day " + day + "... ";
			StartCoroutine ("Fading", day);


			//mainCam.enabled = false;

			//textBox.text = "Day " + day + "... ";

			//imgFade.CrossFadeAlpha(1.0f, 3.0f, false);

			//secuenceCam.enabled = false;
			//mainCam.enabled = true;

		}

	}


	IEnumerator Fading(int day){
		
		yield return new WaitForSeconds(2.0f);
		float i;
		
		for(i = 0.0f; i < 0.95f; i += 0.01f){
			
			
			imgCanvas.alpha += 0.01f;
			yield return null;
		
		}
		GameObject.Find("DayX").GetComponent<Text>().text = "DAY " + (day);
		Game_Master.GMinstance.slotManager.ResetSlots();
		Game_Master.GMinstance.ShuffleDeck();
		GameObject.Find ("BocPeque").GetComponent<Image>().sprite = Game_Master.GMinstance.slotManager.normal;
		
		yield return new WaitForSeconds(2.0f);
		
		
		if (i>= 0.95f){
		//	secuenceCam.enabled = false;
			for(i = 1.0f; i > 0.0f; i -= 0.01f){	
				
				imgCanvas.alpha -= 0.01f;
				yield return null;
				
			}
		}
		
		Game_Master.GMinstance.NewRound();
		
		
		
	}

	public void WonScreen(){

		secuenceCam.enabled = true;
		mainCam.enabled = false;
		
		// Fade.

		print ("Estoy llamando a WonScreen");
		GameObject.FindWithTag("SoundMgr").GetComponent<SoundMgr>().PlayWin();

		imgCanvas.alpha = 1.0f;
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
		GameObject.FindWithTag("SoundMgr").GetComponent<SoundMgr>().PlayLose();
		imgCanvas.alpha = 1.0f;
		textBox.text = "";
		imgFade.color = Color.white;
		imgFade.sprite = LoseScreen;
		
		// Fade.
		
		//secuenceCam.enabled = false; mainCam.enabled = true;

	}

}
