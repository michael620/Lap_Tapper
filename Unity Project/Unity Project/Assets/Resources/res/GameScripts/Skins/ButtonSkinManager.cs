using UnityEngine;
using System.Collections;

public class ButtonSkinManager : MonoBehaviour {

	ButtonSkinChooser[] allButtonSkins;
	string chosenSkin;

	// Use this for initialization
	void Start () {
		allButtonSkins = gameObject.GetComponentsInChildren<ButtonSkinChooser> ();
	}
	
	// Update is called once per frame
	void Update () {
		chosenSkin = PlayerPrefs.GetString ("cButtonColor");
		foreach (ButtonSkinChooser b in allButtonSkins) {
			if(b.skin == chosenSkin) {
				b.choseSkin = true;
			}else {
				b.choseSkin = false;
			}
				}
	}
}
