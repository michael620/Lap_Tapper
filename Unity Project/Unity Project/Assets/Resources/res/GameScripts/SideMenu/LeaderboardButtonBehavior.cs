using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderboardButtonBehavior : MonoBehaviour {
	
	AudioSource sound;
	Animator anim;
	GameObject player;
	bool hasPlayer;
	
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			player = GameObject.FindGameObjectWithTag ("Player");
			hasPlayer = true;
		} else {
			hasPlayer = false;
		}
		sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		
	}
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			player = GameObject.FindGameObjectWithTag ("Player");
			hasPlayer = true;
		} else {
			hasPlayer = false;
		}
		}
	void OnMouseDown() {
					if (hasPlayer) {
						StartCoroutine (sendToLeaderBoard ());
					}
		StartCoroutine (showLeaderboard ());
	}

	IEnumerator sendToLeaderBoard(){
		player.GetComponent<Playerstats> ().updateLeaderboard ();
		yield return new WaitForSeconds(.2f);
	}
	IEnumerator showLeaderboard() {
	sound.Play ();
	yield return new WaitForSeconds(sound.clip.length);
	anim.SetTrigger ("Pressed");
	yield return new WaitForSeconds(anim.playbackTime);
	Social.ShowLeaderboardUI ();
}
}
