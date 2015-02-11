using UnityEngine;
using System.Collections;

public class CreateCamera : MonoBehaviour {
	GameObject MainView;
	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("MainCamera") == null) {
			MainView = (GameObject) Instantiate(Resources.Load("res/Prefabs/MainView"));
		}
	}
}
