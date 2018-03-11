﻿using UnityEngine;
using System.Collections;

public class DisplayTitle : MonoBehaviour {
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = player.GetComponent<Playerstats> ().title;
	}
}
