using UnityEngine;
using System.Collections;

public class ComingSoonButtonBehavior : MonoBehaviour {
	
	AudioSource sound;
	Animator anim;
	
	void Start () {
		sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		
	}
	void OnMouseDown() {
		StartCoroutine(playSound ());
		StartCoroutine(playAnim ());
		Application.LoadLevel ("Blitz");
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
