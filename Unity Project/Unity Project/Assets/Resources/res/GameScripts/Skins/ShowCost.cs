using UnityEngine;
using System.Collections;

public class ShowCost : MonoBehaviour {
	bool hidden;	
	ButtonSkinChooser button;
	CircleColorSkinChooser circle;

	void Start() {
		gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,140);
		button = gameObject.GetComponentInParent<ButtonSkinChooser> ();
		circle = gameObject.GetComponentInParent<CircleColorSkinChooser> ();
		}

	void Update () {
				if (!hidden) {
			if (button !=null ){
				string buttons = PlayerPrefs.GetString ("bButtonSkins");
						if (buttons.Contains(gameObject.GetComponentInParent<ButtonSkinChooser> ().skin)) {
								gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 0);
								hidden = true;
						}
			}
			
			if (circle !=null ){
				string circles = PlayerPrefs.GetString ("bCircleSkins");
				if (circles.Contains(gameObject.GetComponentInParent<CircleColorSkinChooser> ().skin)) {
					gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 0);
					hidden = true;
				}
			}
				}
		}
}
