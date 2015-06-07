using UnityEngine;
using System.Collections;

public class SoundMgr : MonoBehaviour {

//	public int size;
	public AudioClip[] soundList;
	public AudioSource audioS;
	public bool started = false;

	// Use this for initialization
	void Start () {
		//soundList = new AudioSource[size];
	}
	
	void Update(){
		if (!audioS.isPlaying && started){
			audioS.clip = soundList[1];
			audioS.Play();
			audioS.loop = true;
		}
	}
	// Update is called once per frame
	
	public void PlaySound(string id){
		AudioClip played = null;
		for (int i = 0; i< soundList.Length; i++){
		
			if (id == soundList[i].name) played = soundList[i];
		}
		if (played != null) audioS.PlayOneShot (played, 1.0f);
	}
	

	public void PlayIntro(){
		started = true;
		audioS.clip = soundList[0];
		audioS.Play();		
		
	}
	
	public void PlayWin(){	
		audioS.clip = soundList[2];
		audioS.Play();		
		
	}
	
	public void PlayLose(){	
		audioS.clip = soundList[1];
		audioS.Play();		
		
	}
	
	
	public void PlayCorrect(){	
		audioS.clip = soundList[0];
		audioS.Play();		
		
	}
	
	
	public void PlayWrong(){	
		audioS.clip = soundList[3];
		audioS.Play();		
		
	}
	
	
	
}
