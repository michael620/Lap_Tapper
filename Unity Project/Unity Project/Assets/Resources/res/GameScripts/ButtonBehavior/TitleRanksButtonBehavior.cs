using UnityEngine;
using System.Collections;

public class TitleRanksButtonBehavior : MonoBehaviour {
	
	AudioSource sound;
	
	void Start () {
		sound = GetComponent<AudioSource> ();
		
	}
	void OnMouseDown() {
		playSound ();
		Application.LoadLevel ("TitleRanks");
	}
	IEnumerator playSound() {
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
	}
}
