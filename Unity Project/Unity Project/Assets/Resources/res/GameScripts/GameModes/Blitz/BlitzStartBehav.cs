using UnityEngine;
using System.Collections;

public class BlitzStartBehav : MonoBehaviour {
	
	GameObject player;
	bool pressed = false;
	Animator anim;
	AudioSource sound;
	Playerstats stats;
	float currtime = 0;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponentInChildren<Animator> ();
		sound = GetComponent<AudioSource> ();
		stats = player.GetComponent<Playerstats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed) {
			//do something when the player tapped

			stats.blitzStart = true;

		}
		if (stats.blitzStart == true && currtime < 10) {
			currtime += Time.deltaTime;
				}
		if (stats.blitzStart == true && currtime >= 10) {
			currtime = 0;
			stats.blitzStart = false;
			pressed = false;
				}
	}
	
	void OnMouseDown() {
		pressed = true;
		anim.SetTrigger ("Pressed");
		sound.Play ();
	}

		

}
