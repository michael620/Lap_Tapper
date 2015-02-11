using UnityEngine;
using System.Collections;

public class ToIn : MonoBehaviour {
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
						if (sideMenu.GetComponent<SideMenuBehavior> ().isIn) {
								float x = curPos.x;
								float y = curPos.y;
								transform.position = new Vector3 (x, y, 3);
						}
						if (sideMenu.GetComponent<SideMenuBehavior> ().isOut) {
								float x = curPos.x;
								float y = curPos.y;
								transform.position = new Vector3 (x, y, -3);
						}
				}
	}
	
	void OnMouseDown(){
		if (sideMenu.GetComponent<SideMenuBehavior> ().isOut) {
			sideMenu.GetComponent<SideMenuBehavior> ().isSlidingIn = true;
		}
	}
}
