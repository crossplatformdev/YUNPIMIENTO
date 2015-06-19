using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {

	[SerializeField] private AudioSource source;
	private MovieTexture intro;
	private RawImage image;


	void Awake(){

		image = GetComponent<RawImage>();
		intro = (MovieTexture)image.mainTexture;
		source = this.GetComponent<AudioSource>();
		source.clip = intro.audioClip;
	}

	void Start(){

		intro.Play();
		source.Play();

	}

	void Update(){

		if(intro.isPlaying != true){

			this.GetComponent<LoadManager>().Loader(2);

		}

	}
}
