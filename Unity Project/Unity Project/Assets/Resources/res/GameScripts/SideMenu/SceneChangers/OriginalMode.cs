using UnityEngine;
using System.Collections;

public class OriginalMode : MonoBehaviour {
	
	AudioSource sound;
	Animator anim;
	GameObject sideMenu;
	
	void Start () {
		sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
		sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		
	}
	void OnMouseDown() {
		StartCoroutine(playSound ());
		StartCoroutine(playAnim ());
		if (Application.loadedLevelName != "Main") {
						Application.LoadLevel ("Main");
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
		anim.SetTrigger ("Pressed");
		yield return new WaitForSeconds(anim.playbackTime);
	}
}
