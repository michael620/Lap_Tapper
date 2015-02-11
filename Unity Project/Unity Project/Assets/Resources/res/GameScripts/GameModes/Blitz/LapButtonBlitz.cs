using UnityEngine;
using System.Collections;

public class LapButtonBlitz : MonoBehaviour {
	
	GameObject player;
	bool pressed = false;
	Animator anim;
	Animator circle;
	AudioSource sound;
	Playerstats stats;
	bool sentTrigger;
	float currtime = 0;
	public bool done = false;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponentInChildren<Animator> ();
		circle = GameObject.Find ("StatsCircle").GetComponent<Animator> ();
		sound = GetComponent<AudioSource> ();
		stats = player.GetComponent<Playerstats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (stats.blitzStart == false && done == false) {
			if (pressed) {
				circle.SetBool ("Start", true);
				//do something when the player tapped
				stats.blitzStart = true;
				pressed = false;
			}

				}
		if (stats.blitzStart && (currtime <= 10)) {
			currtime += Time.deltaTime;
			if (pressed) {
				pressed = false;
				//do something when the player tapped lap
				stats.blitzscore ++;
				stats.curLaps1 ++;
				stats.curLaps2 ++;
				stats.curLaps3 ++;
				stats.curLaps4 ++;

			}
		if ((stats.blitzStart) && (currtime > 10)) {
				currtime = 0;
				done = true;
				stats.blitzStart = false;
				pressed = false;
				circle.SetBool ("Start", false);

			}
		}
	
	}
	
	void OnMouseDown() {
		pressed = true;
		anim.SetTrigger ("Pressed");
		sound.Play ();
	}
}
