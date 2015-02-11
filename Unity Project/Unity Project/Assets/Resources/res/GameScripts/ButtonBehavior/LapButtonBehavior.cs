using UnityEngine;
using System.Collections;

public class LapButtonBehavior : MonoBehaviour {

	GameObject player;
	bool hasLapped = false;
	Animator anim;
	Animator circle;
	AudioSource sound;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponentInChildren<Animator> ();
		circle = GameObject.Find ("StatsCircle").GetComponent<Animator> ();
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLapped) {
			//do something when the player tapped lap
			Playerstats stats = player.GetComponent<Playerstats> ();
			stats.startedPlay = true;
			stats.score ++;
			stats.curLaps1 ++;
			stats.curLaps2 ++;
			stats.curLaps3 ++;
			stats.curLaps4 ++;
			hasLapped = false;
				}
	}

	void OnMouseDown() {
		hasLapped = true;
		anim.SetTrigger ("Pressed");
		circle.SetTrigger ("Pressed");
		sound.Play ();
		}
}
