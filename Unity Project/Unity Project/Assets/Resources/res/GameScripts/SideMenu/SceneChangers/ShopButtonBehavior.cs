using UnityEngine;
using System.Collections;

public class ShopButtonBehavior : MonoBehaviour {
	
	
	AudioSource sound;
	
	GameObject sideMenu;
	
	void Start () {
		sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
		sound = GetComponent<AudioSource> ();
		
	}
	void OnMouseDown() {
		StartCoroutine(playSound ());
		StartCoroutine(playAnim ());
		if (Application.loadedLevelName != "Shop") {
			Application.LoadLevel ("Shop");
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
