using UnityEngine;
using System.Collections;

public class DisplayLPM : MonoBehaviour {
	
	GameObject player;
	public byte avalue;
	GameObject sideMenu;
	SpriteRenderer messageDisplay;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerState");
		sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
		messageDisplay = GameObject.Find ("GraphicManager/MessageDisplay").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (sideMenu == null) {
			sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
		} else { changeAlpha();
	}
	}
	void changeAlpha(){
		int curLpm = player.GetComponent<Playerstats> ().lpm;
		if (curLpm > 0) {
			player.GetComponent<Playerstats>().isPlaying = true;
			messageDisplay.color = new Color32(255,255,255,0);
			float r = GetComponent<GUIText>().color.r;
			float g = GetComponent<GUIText>().color.g;
			float b = GetComponent<GUIText>().color.b;
			
			if ((sideMenu.GetComponent<SideMenuBehavior>().isIn)&&
				(!sideMenu.GetComponent<SideMenuBehavior>().isSlidingIn)&&
			(!sideMenu.GetComponent<SideMenuBehavior>().isSlidingOut)){
				
				guiText.color = new Color(r,g,b,1f);
			}else {
				guiText.color = new Color(r,g,b,0f);
			}
			guiText.text = curLpm.ToString () + " LPM";
		} else {
			player.GetComponent<Playerstats>().isPlaying = false;
			if ((sideMenu.GetComponent<SideMenuBehavior>().isIn)&&
			    (!sideMenu.GetComponent<SideMenuBehavior>().isSlidingIn)&&
			    (!sideMenu.GetComponent<SideMenuBehavior>().isSlidingOut)){
				
				messageDisplay.color = new Color32(255,255,255,avalue);
			} else {
				
				messageDisplay.color = new Color32(255,255,255,0);
			}
			float r = GetComponent<GUIText>().color.r;
			float g = GetComponent<GUIText>().color.g;
			float b = GetComponent<GUIText>().color.b;
			guiText.color = new Color(r,g,b,0);
		}

	}
}
