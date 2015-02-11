using UnityEngine;
using System.Collections;

public class DisplayTime : MonoBehaviour {
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		int totalTime = player.GetComponent<Playerstats> ().playtime;
		int days = Mathf.FloorToInt (totalTime / (60 * 60 * 24));
		int hours = Mathf.FloorToInt ((totalTime - days*(60 * 60 * 24))/(60*60));
		int minutes = Mathf.FloorToInt ((totalTime - days*(60 * 60 * 24) - hours*(60*60))/60);
		int seconds = Mathf.FloorToInt ((totalTime - days*(60 * 60 * 24) - hours*(60*60)) - minutes*60);
		guiText.text = days.ToString () + " Days" + "\n" + 
						hours.ToString ("00") + ":" + minutes.ToString ("00") + ":" + seconds.ToString ("00");


	}
}
