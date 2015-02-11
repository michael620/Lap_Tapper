using UnityEngine;
using System.Collections;

public class MessageToDisplay : MonoBehaviour {
	int num;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerState");

	}
	
	// Update is called once per frame
	void Update () {
		num = player.GetComponent<Playerstats> ().messageNumToDisplay;
		GetComponent<Animator> ().SetInteger ("MessageNum", num);
	}
}
