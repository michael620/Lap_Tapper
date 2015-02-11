using UnityEngine;
using System.Collections;

public class ResetButtonBehavior : MonoBehaviour {
	
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
			detCoin();
			player = GameObject.FindGameObjectWithTag ("Player");
			stats = player.GetComponent<Playerstats> ();
			save ();
			hasReset = false;
		}
	}
	
	void OnMouseDown() {
		hasReset = true;
		anim.SetTrigger ("Pressed");
		sound.Play ();
	}
	void save() {
		int score;
		int resetsovern;
		float timer;
		string title;
		int newLapCoin;
		
		score = player.GetComponent<Playerstats> ().score;
		resetsovern = player.GetComponent<Playerstats> ().resetsovern;
		timer = (float)player.GetComponent<Playerstats> ().playtime;
		title = player.GetComponent<Playerstats> ().title;
		newLapCoin = player.GetComponent<Playerstats> ().lapCoin;
		
		PlayerPrefs.SetInt ("pScore", score);
		PlayerPrefs.SetInt ("pReset", resetsovern);
		PlayerPrefs.SetInt ("pLapCoin", newLapCoin);
		PlayerPrefs.SetFloat ("pTime", timer);
		PlayerPrefs.SetString ("pTitle", title);

	}
	void detCoin() {
		int score = stats.score;
		if (score < 1000) {
			stats.lapCoin += score;
		}
		if ((score >= 1000)&&(score < 2500)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.02f);
		}
		
		if ((score >= 2500)&&(score < 5000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.05f);
		}
		
		if ((score >= 5000)&&(score < 9000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.1f);
		}
		
		if ((score >= 9000)&&(score < 10000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.15f);
		}
		
		if ((score >= 10000)&&(score < 25000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.22f);
		}
		
		if ((score >= 25000)&&(score < 50000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.5f);
		}
		
		if ((score >= 50000)&&(score < 100000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*1.8f);
		}
		
		if ((score >= 100000)) {
			stats.lapCoin += Mathf.FloorToInt((float)score*2.0f);
		}
		stats.score = 0;

	}
}
