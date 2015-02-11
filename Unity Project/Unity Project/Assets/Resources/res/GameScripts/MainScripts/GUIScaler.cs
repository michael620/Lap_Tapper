 using UnityEngine;
using System.Collections;

public class GUIScaler : MonoBehaviour {

	//Base value of resolution screen for which the text is made
	public float origW = 375f;
	public float origH = 600f;
	
	
	void Start(){   
		scaleText ();
	}
	void scaleText(){ 
		float scaleX = Screen.width / origW; //your scale x
		float scaleY = Screen.height / origH; //your scale y
		
		//Find all GUIText object on your scene
		GUIText[] texts =  FindObjectsOfType(typeof(GUIText)) as GUIText[]; 
		
		foreach(GUIText myText in texts) { //find your element of text
			
			Vector2 pixOff = myText.pixelOffset; //your pixel offset on screen
			int origSizeText = myText.fontSize;
			myText.pixelOffset = new Vector2(pixOff.x*scaleX, pixOff.y*scaleY); //new position
			float floatFontSize = origSizeText * scaleX; //new size font in a float
			myText.fontSize = (int)Mathf.RoundToInt(floatFontSize); // Closest value of fontSize
		}
	}
	void OnLevelWasLoaded(int i) {
		scaleText ();
	}
}