using UnityEngine;
using System.Collections;

public class ToOut : MonoBehaviour {
	GameObject sideMenu;
	Vector3 curPos;
	void Start() {
		sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
		curPos = transform.position;
	}
	void Update() {
		if (sideMenu == null) {
						sideMenu = GameObject.FindGameObjectWithTag ("SideMenu");
				} else {
						if ((!sideMenu.GetComponent<SideMenuBehavior> ().isIn) || (sideMenu.GetComponent<SideMenuBehavior> ().isSlidingIn)) {
								float x = curPos.x;
								float y = curPos.y;
								transform.position = new Vector3 (x, y, 3);
								if (gameObject.GetComponent<SpriteRenderer> () != null) {
										SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
				
										float r = sprite.color.r;
										float g = sprite.color.g;
										float b = sprite.color.b;
										float a = sprite.color.a;
				
										sprite.color = new Color (r, g, b, 0f);
								}
						} else {
								float x = curPos.x;
								float y = curPos.y;
								transform.position = new Vector3 (x, y, -3);
								if (gameObject.GetComponent<SpriteRenderer> () != null) {
										SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
				
										float r = sprite.color.r;
										float g = sprite.color.g;
										float b = sprite.color.b;
										float a = sprite.color.a;
				
										sprite.color = new Color (r, g, b, 1f);
								}
						}
				}
	}

	void OnMouseDown(){
		if (sideMenu.GetComponent<SideMenuBehavior> ().isIn) {
			sideMenu.GetComponent<SideMenuBehavior> ().isSlidingOut = true;
				}
	}
}
