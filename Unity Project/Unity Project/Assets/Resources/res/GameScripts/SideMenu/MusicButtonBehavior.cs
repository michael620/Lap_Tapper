using UnityEngine;
using System.Collections;

public class MusicButtonBehavior : MonoBehaviour {
		
		AudioSource sound;
	GameObject audioButton;

		void Start() {
		sound = GetComponent<AudioSource> ();
		audioButton = GameObject.FindGameObjectWithTag ("AudioButton");
			
		}
		void OnMouseDown() {
				GetComponent<Animator> ().SetTrigger ("Pressed");
				StartCoroutine(playSound ());
				if (GameObject.FindGameObjectWithTag ("Music") != null) {
						Destroy (GameObject.FindGameObjectWithTag ("Music"));
						GetComponentInChildren<ToggleOn> ().changeBool (false);
				} else {
			if (audioButton.GetComponentInChildren<ToggleOn>().toggle) {
								Destroy (GameObject.FindGameObjectWithTag ("Music"));
								GetComponentInChildren<ToggleOn> ().changeBool (true);
								GameObject MainMusic = (GameObject)Instantiate (Resources.Load ("res/Prefabs/MainMusic", typeof(GameObject)));
								MainMusic.GetComponent<AudioSource> ().Play ();
						}
				}
		}
		
		IEnumerator playSound() {
			sound.Play ();
			yield return new WaitForSeconds(sound.clip.length);
		}
	}
