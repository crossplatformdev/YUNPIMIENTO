using UnityEngine;
using System.Collections;

public class SoundMgr : MonoBehaviour {

//	public int size;
	public AudioSource[] soundList;
	

	// Use this for initialization
	void Start () {
		//soundList = new AudioSource[size];
	}
	
	// Update is called once per frame
	
	public void PlaySound(string id){
		AudioSource played = null;
		for (int i = 0; i< soundList.Length; i++){
			if (id == soundList[i].name) played = soundList[i];
		}
		if (played != null) played.Play();
	}
	
}
