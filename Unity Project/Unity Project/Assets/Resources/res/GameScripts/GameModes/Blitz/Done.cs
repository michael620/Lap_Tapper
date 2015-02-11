using UnityEngine;
using System.Collections;

public class Done : MonoBehaviour {

	GameObject lapButton;
	bool done;
	GameObject cashIn;
	bool hasDialog;

	// Use this for initialization
	void Start () {
		lapButton = GameObject.Find ("GraphicManager/LapButton");
	}
	
	// Update is called once per frame
	void Update () {
		done = lapButton.GetComponent<LapButtonBlitz>().done;
		if (done&&(!hasDialog)) {
			displayCashIn();
				}
	}

	void displayCashIn() {
		cashIn = (GameObject) Instantiate (Resources.Load ("res/Prefabs/CashInDialog"));
		hasDialog = true;
	}
}
