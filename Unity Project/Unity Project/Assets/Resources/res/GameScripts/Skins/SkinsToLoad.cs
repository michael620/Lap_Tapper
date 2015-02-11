using UnityEngine;
using System.Collections;

public class SkinsToLoad : MonoBehaviour
{

		string buttonC;
	string buttonS;
		string circleC;
	string circleS;
		GameObject lapButton;
	GameObject resetButton;
	SpriteRenderer lapAni;
	SpriteRenderer resetAni;
		GameObject circleSp;
	Sprite[] buttonSkin;
	Color32 color;
	public bool isLapButton;
	public bool isResetButton;
	public bool isCircle;

		// Use this for initialization
		void Start ()
	{
		buttonS = PlayerPrefs.GetString ("cButtonSkin", "Default");
		circleS = PlayerPrefs.GetString ("cCircleSkin", "Default");
		buttonC = PlayerPrefs.GetString ("cButtonColor", "Default");
		circleC = PlayerPrefs.GetString ("cCircleColor", "Default");
		buttonSkin = Resources.LoadAll<Sprite> ("res/Textures/" + buttonS + "/MainButtons/Buttons");
		setSkin ();
		}

		void setSkin ()
		{
		if (isLapButton) {
			lapButton = GameObject.Find ("LapButton");
			lapAni = GameObject.Find ("LapAni").GetComponent<SpriteRenderer> ();
						setLapButton ();
				}
		if (isResetButton) {
			resetButton = GameObject.Find ("ResetButton");
			resetAni = GameObject.Find ("ResetAni").GetComponent<SpriteRenderer> ();
						setResetButton ();
				}
		if (isCircle) {
			circleSp = GameObject.Find ("StatsCircle");
						setCircle ();
				}
		}

		void setLapButton ()
	{
		switch (buttonC) {
			
		case "Red":
			color = new Color32(255,0,0,255);
			colorLapButton(color);
			break;
		case "Green":
			color = new Color32(31,173,20,255);
			colorLapButton(color);
			break;
		case "Blue":
			color = new Color32(0,54,255,255);
			colorLapButton(color);
			break;
		case "Purple":
			color = new Color32(138,0,255,255);
			colorLapButton(color);
			break;
		case "Magenta":
			color = new Color32(240,0,255,255);
			colorLapButton(color);
			break;
		case "Lemon":
			color = new Color32(222,255,0,255);
			colorLapButton(color);
			break;
		case "Orange":
			color = new Color32(255,127,0,255);
			colorLapButton(color);
			break;
		case "Cyan":
			color = new Color32(0,255,255,255);
			colorLapButton(color);
			break;
		case "Brown":
			color = new Color32(110,67,27,255);
			colorLapButton(color);
			break;
		case "Gold":
			color = new Color32(234,193,0,255);
			colorLapButton(color);
			break;
		case "Black":
			color = new Color32(0,0,0,255);
			colorLapButton(color);
			break;
		default:
			lapButton.GetComponent<SpriteRenderer>().sprite = buttonSkin [1];
			lapAni.color = new Color32(181,181,181,255); 
			break;
			
		}
		}

	void setResetButton ()
	{
		switch (buttonC) {
			
		case "Red":
			color = new Color32(255,0,0,200);
			colorResetButton(color);
			break;
		case "Green":
			color = new Color32(31,173,20,200);
			colorResetButton(color);
			break;
		case "Blue":
			color = new Color32(0,54,255,200);
			colorResetButton(color);
			break;
		case "Purple":
			color = new Color32(138,0,255,200);
			colorResetButton(color);
			break;
		case "Magenta":
			color = new Color32(240,0,255,200);
			colorResetButton(color);
			break;
		case "Lemon":
			color = new Color32(222,255,0,200);
			colorResetButton(color);
			break;
		case "Orange":
			color = new Color32(255,127,0,200);
			colorResetButton(color);
			break;
		case "Cyan":
			color = new Color32(0,255,255,200);
			colorResetButton(color);
			break;
		case "Brown":
			color = new Color32(110,67,27,200);
			colorResetButton(color);
			break;
		case "Gold":
			color = new Color32(234,193,0,200);
			colorResetButton(color);
			break;
		case "Black":
			color = new Color32(0,0,0,200);
			colorResetButton(color);
			break;

		default:
			resetButton.GetComponent<SpriteRenderer> ().sprite = buttonSkin [4];
			resetAni.color = new Color32(181,181,181,255); 
			break;
			
		}
	}

		void setCircle ()
		{
		switch (circleC) {
			
		case "Red":
			color = new Color32(255,0,0,255);
			colorCircle(color);
			break;
		case "Green":
			color = new Color32(31,173,20,255);
			colorCircle(color);
			break;
		case "Blue":
			color = new Color32(0,54,255,255);
			colorCircle(color);
			break;
		case "Purple":
			color = new Color32(138,0,255,255);
			colorCircle(color);
			break;
		case "Magenta":
			color = new Color32(240,0,255,255);
			colorCircle(color);
			break;
		case "Lemon":
			color = new Color32(222,255,0,255);
			colorCircle(color);
			break;
		case "Orange":
			color = new Color32(255,127,0,255);
			colorCircle(color);
			break;
		case "Cyan":
			color = new Color32(0,255,255,255);
			colorCircle(color);
			break;
		case "Brown":
			color = new Color32(110,67,27,255);
			colorCircle(color);
			break;
		case "Gold":
			color = new Color32(234,193,0,255);
			colorCircle(color);
			break;
		case "Black":
			color = new Color32(0,0,0,255);
			colorCircle(color);
			break;

		default:
			if (Application.loadedLevelName=="Blitz") {
				circleSp.GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load ("res/Textures/" + circleS + "/StatsCircle/AnimatorCont");
			}else {
			circleSp.GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load ("res/Textures/" + circleS + "/StatsCircle/Animator");
			}
			break;
		
				}
		}
	void colorCircle(Color32 color) {
		if(Application.loadedLevelName=="Blitz") {
			circleSp.GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load ("res/Textures/" + circleS + "/StatsCircle/AnimatorCont");
		}else {
		circleSp.GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load ("res/Textures/" + circleS + "/StatsCircle/Animator");
		}
			circleSp.GetComponent<SpriteRenderer> ().color = color;
	}
	void colorLapButton(Color32 color) {
		lapButton.GetComponent<SpriteRenderer> ().sprite = buttonSkin [1];
		lapAni.color = new Color32(181,181,181,255); 
		lapButton.GetComponent<SpriteRenderer> ().color = color;
	}
	void colorResetButton(Color32 color) {
		resetButton.GetComponent<SpriteRenderer> ().sprite = buttonSkin [4];
		resetAni.color = new Color32(181,181,181,255); 
		resetButton.GetComponent<SpriteRenderer> ().color = color;
	}
}
