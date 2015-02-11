using UnityEngine;
using System.Collections;

public class WelcomeTimer : MonoBehaviour {

	float timer;
	public float displayTime;

	// Update is called once per frame
	void Update () {
		if (timer >= displayTime) {
			Application.LoadLevel(Application.loadedLevel + 1);
				}

		timer += Time.deltaTime;

	}
}
