using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	GameObject player;
	int startingFont;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		startingFont = guiText.fontSize;
	}
	
	// Update is called once per frame
	void Update () {
		detFont (player.GetComponent<Playerstats> ().score);
	}

	void detFont(int score){
		guiText.text = score.ToString();
	}
}
