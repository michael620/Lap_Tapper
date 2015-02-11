using UnityEngine;
using System.Collections;

public class ResetButtonTutorial : MonoBehaviour {
	
	GameObject player;
	bool hasReset = false;
	Animator anim;
	AudioSource sound;
	Playerstats stats;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponentInChildren<Animator> ();
		sound = GetComponent<AudioSource> ();
		stats = player.GetComponent<Playerstats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasReset) {
			//do something when the player tapped reset
			stats.score = 0;
			player = GameObject.FindGameObjectWithTag ("Player");
			stats = player.GetComponent<Playerstats> ();
			hasReset = false;
		}
	}
	
	void OnMouseDown() {
		hasReset = true;
		anim.SetTrigger ("Pressed");
		sound.Play ();
	}
}
