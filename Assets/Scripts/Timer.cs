using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text textTimer;

	private float timePassed;
	[SerializeField] private float maxTime;
	private bool roundSucces;
	private bool roundFailed;
	private bool timerRunning;

	private int clockState; // 0 es en las 12, 1 es en las 3, 2 es en las 6, 4 es en las 

	// Use this for initialization
	void Awake () {
	
		timePassed = maxTime;
		roundSucces = false;
		roundFailed = false;
	
	}

	public bool timerPassed (){ // Para establecer una condicion desde la gestion del juego.

		return roundFailed;

	}

	public void roundWasSuccesful(){ // Cuando se completa con exito la ronda.

		roundSucces = true;

	}

	public void launchTimer(){

		if(!timerRunning){

			ResetTimer ();

			if(maxTime < 5) maxTime = 10;

			StartCoroutine ("roundTimer", maxTime);

			timerRunning = true;

		}else{

			print ("Ya existe un timer");

		}


	}

	public void launchTimer(int time){

		if(!timerRunning){

			ResetTimer ();

			if(time < 5) time = 10;

			StartCoroutine ("roundTimer", time);

			timerRunning = true;

		}else{

			print ("Ya existe un timer");
			
		}

	}

	private IEnumerator roundTimer(float time){

		for (float i = 0; i < time; i += Time.deltaTime){

			timePassed -= Time.deltaTime;
		
			textTimer.text = " Time left: " + (int)timePassed;

			if(roundSucces == true || roundFailed == true){

				print ("paro antes de tiempo");

				timerRunning = false;

				yield break;
				// break;
				print ("No para la corrutina");

			}

			if(timePassed <= 0){

				roundFailed = true;

				timerRunning = false;

			}

			yield return null;

		}
	}

	private void changeClockState(int stt){

		clockState = stt;

	}

	public int getClockState(){

		if(timePassed == maxTime){

			clockState = 0;

		}else if(timePassed > (maxTime * 0.75f)){

			clockState = 4;

		}else if(timePassed > (maxTime * 0.5f)){

			clockState = 3;

		}else if(timePassed > (maxTime * 0.25f)){

			clockState = 2;

		}else {

			clockState = 1;

		}

		return clockState;

	}

	public bool isRunning(){

		return timerRunning;

	}

	public void ResetTimer(){

		timePassed = maxTime;
		roundSucces = false;
		roundFailed = false;

	}

}
