using UnityEngine;
using System.Collections;

public class LapButtonTutorial : MonoBehaviour {
	
	GameObject player;
	bool hasLapped = false;
	Animator anim;
	Animator circle;
	AudioSource sound;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponentInChildren<Animator> ();
		circle = GameObject.FindGameObjectWithTag ("Circle").GetComponent<Animator>();
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLapped) {
			//do something when the player tapped lap
			Playerstats stats = player.GetComponent<Playerstats> ();
			stats.score ++;
			hasLapped = false;
		}
	}
	
	void OnMouseDown() {
		hasLapped = true;
		anim.SetTrigger ("Pressed");
		circle.SetTrigger ("Lapped");
		sound.Play ();
	}
}
