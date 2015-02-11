using UnityEngine;
using System.Collections;

public class AudioButtonBehavior : MonoBehaviour {

	GameObject musicButton;
	
	AudioSource sound;
	void Start() {
		sound = GetComponent<AudioSource> ();
		musicButton = GameObject.FindGameObjectWithTag ("MusicButton");
		
	}
	void OnMouseDown() {
		GetComponent<Animator> ().SetTrigger ("Pressed");
		StartCoroutine(playSound ());
		if (AudioListener.volume == 1) {
			AudioListener.volume = 0;
			GetComponentInChildren<ToggleOn> ().changeBool(false);
			musicButton.GetComponentInChildren<ToggleOn>().changeBool(false);
				} else {
			AudioListener.volume = 1;
			GetComponentInChildren<ToggleOn> ().changeBool(true);
			musicButton.GetComponentInChildren<ToggleOn>().changeBool(true);
			GameObject MainMusic = (GameObject)Instantiate(Resources.Load("res/Prefabs/MainMusic", typeof(GameObject)));
			MainMusic.GetComponent<AudioSource>().Play();
				}
	}
	
	IEnumerator playSound() {
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
	}
}