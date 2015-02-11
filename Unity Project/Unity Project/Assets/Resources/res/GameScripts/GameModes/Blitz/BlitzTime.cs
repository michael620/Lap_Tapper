using UnityEngine;
using System.Collections;

public class BlitzTime : MonoBehaviour {

	GameObject player;
	float countDown = 10;
	Playerstats stats;
	bool started;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		stats = player.GetComponent<Playerstats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (stats.blitzStart) {
			started = true;
				}
		if (started&& (countDown>0)) {
			countDown -= Time.deltaTime;
				}
		if (countDown < 0) {
			countDown = 0;
				}
		guiText.text = System.Math.Round(countDown, 2).ToString();
		
		
	}
}
