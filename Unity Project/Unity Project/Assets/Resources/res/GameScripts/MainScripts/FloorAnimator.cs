using UnityEngine;
using System.Collections;

public class FloorAnimator : MonoBehaviour {

	Animator floorAni;
	int currAni;
	int LPM;
	public float interval;
	
	
	// Use this for initialization
	void Start () {
		floorAni = gameObject.GetComponent<Animator> ();
		LPM = GameObject.Find("PlayerState").GetComponent<Playerstats>().lpm;
	}
	
	// Update is called once per frame
	void Update () {
		interval += Time.deltaTime;
		currAni = floorAni.GetInteger ("detAni");
		if (interval >= 1) {
			if (LPM < 100) {
				if (currAni != 0) {
					floorAni.SetInteger ("detAni", 0);
				}
				interval = 0;
			}
			
			if (LPM >= 100) {
				if (currAni != 1) {
					floorAni.SetInteger ("detAni", 1);
				}
				interval = 0;
			}
			
			if (LPM >= 350) {
				if (currAni != 2) {
					floorAni.SetInteger ("detAni", 2);
				}
				interval = 0;
			}
			
			if (LPM > 350) {
				if (currAni != 3) {
					floorAni.SetInteger ("detAni", 3);
				}
				interval = 0;
			}
			
		}
		
		
	}
}
