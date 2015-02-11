using UnityEngine;
using System.Collections;

public class ReturnButtonBehavior : MonoBehaviour {
	
	AudioSource sound;
	void Start() {
		sound = GetComponent<AudioSource> ();

	}
	void OnMouseDown() {
		playSound ();
		Application.LoadLevel ("Main");
			
		}
	
	IEnumerator playSound() {
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
	}

	void Update (){
	if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("Main");
	}
	}
	}

