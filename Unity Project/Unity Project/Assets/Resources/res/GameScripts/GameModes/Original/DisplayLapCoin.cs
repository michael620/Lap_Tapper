using UnityEngine;
using System.Collections;

public class DisplayLapCoin : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = PlayerPrefs.GetInt("pLapCoin").ToString();
	}
}
