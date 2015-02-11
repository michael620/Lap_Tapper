using UnityEngine;
using System.Collections;

public class CreateAd : MonoBehaviour {
	GameObject ad;
	// Use this for initialization
	void Update () {
		ad = GameObject.FindGameObjectWithTag ("Ads");
		if (ad == null) {
			ad = (GameObject) Instantiate(Resources.Load("res/Prefabs/BottomBannerAd"));
				}
	}
}
