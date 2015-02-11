using UnityEngine;
using System.Collections;

public class CircleSkinManager : MonoBehaviour {
	
	CircleColorSkinChooser[] allCircleSkins;
	string chosenSkin;
	
	// Use this for initialization
	void Start () {
		allCircleSkins = gameObject.GetComponentsInChildren<CircleColorSkinChooser> ();
	}
	
	// Update is called once per frame
	void Update () {
		chosenSkin = PlayerPrefs.GetString ("cCircleColor");
		foreach (CircleColorSkinChooser b in allCircleSkins) {
			if(b.skin == chosenSkin) {
				b.choseSkin = true;
			}else {
				b.choseSkin = false;
			}
		}
	}
}
