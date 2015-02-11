using UnityEngine;
using System.Collections;

public class AvatarAnimator : MonoBehaviour {

	Animator avatarAni;
	int currAni;
	int LPM;
	Playerstats player;


	// Use this for initialization
	void Start () {
		avatarAni = gameObject.GetComponent<Animator> ();
		player = GameObject.Find("PlayerState").GetComponent<Playerstats>();
	}
	
	// Update is called once per frame
	void Update () {
		LPM = player.lpm;
		currAni = avatarAni.GetInteger ("detAni");
		if (LPM == 0) {
			if (currAni != 0) {
				avatarAni.SetInteger ("detAni", 0);
			}
		}
		if ((LPM > 0)&&(LPM < 250)) {
				if (currAni != 1) {
				avatarAni.SetInteger ("detAni", 1);
				}
			}

		if (LPM >= 250&&(LPM < 500)) {
				if (currAni != 2) {
				avatarAni.SetInteger ("detAni", 2);
				}
			}

			if (LPM >= 500) {
				if (currAni != 3) {
				avatarAni.SetInteger ("detAni", 3);
				}
			}



	}
}
