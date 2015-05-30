using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
	
	public Texture2D fadeTexture;
	public float fadeSpeed = 0.8f;
	
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDirection = -1;
	
	void OnGUI()
	{
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		
		GUI.color = new Color (GUI.color.r,GUI.color.g,GUI.color.b,alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fadeTexture);
	}
	
	public float StartFade(int direction)
	{
		fadeDirection = direction;
		return fadeSpeed;
	}
	
	void OnLevelWasLoaded()
	{
		StartFade (-1);
	}

	public IEnumerator FadeScene()
	{
		float fadeTime = StartFade(1);
		yield return new WaitForSeconds (fadeTime);
	}
}