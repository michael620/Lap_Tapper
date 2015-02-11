using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class AboutButtonBehavior : MonoBehaviour {
	
	AudioSource sound;
	
	GameObject sideMenu;
	
	void Start () {
		sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
		sound = GetComponent<AudioSource> ();
		
	}
	void OnMouseDown() {
		StartCoroutine(playSound ());
		StartCoroutine(playAnim ());
		if (Application.loadedLevelName != "AboutScene") {
			Application.LoadLevel ("AboutScene");
		} else {
			if (sideMenu.GetComponent<SideMenuBehavior> ().isOut) {
				sideMenu.GetComponent<SideMenuBehavior> ().isSlidingIn = true;
			}
		}
	}
	IEnumerator playSound() {
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
	}
	IEnumerator playAnim() {
		GetComponent<Animator> ().SetTrigger ("Pressed");
		yield return new WaitForSeconds(GetComponent<Animator> ().playbackTime);
	}
}
