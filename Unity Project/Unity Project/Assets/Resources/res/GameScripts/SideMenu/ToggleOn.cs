using UnityEngine;
using System.Collections;

public class ToggleOn : MonoBehaviour {

	public bool toggle = true;
	bool curToggle;
	void Start () {
		curToggle = GetComponent<Animator> ().GetBool ("On");
	}
	// Update is called once per frame
	void Update () {
		if (toggle != curToggle) {
			GetComponent<Animator> ().SetBool ("On", toggle);
			curToggle = toggle;
				}
	}

	public void changeBool(bool b) {
		toggle = b;
	}
}
