using UnityEngine;
using System.Collections;

public class GenerateSideMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	if (GameObject.FindGameObjectWithTag ("SideMenu") == null) {
			Instantiate(Resources.Load("res/Prefabs/SideMenu"));
		}
		DontDestroyOnLoad (gameObject);
	}
}
