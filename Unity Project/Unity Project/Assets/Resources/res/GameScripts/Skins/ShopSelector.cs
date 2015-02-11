using UnityEngine;
using System.Collections;

public class ShopSelector : MonoBehaviour {

	ShopButton[] allShopButton;
	string chosenSkin;
	string curShop;
	
	// Use this for initialization
	void Start () {
		curShop = "ButtonSkins";
		allShopButton = gameObject.GetComponentsInChildren<ShopButton> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (ShopButton b in allShopButton) {
			if(b.chose) {
				b.selected = true;
				curShop = b.selectShop;
			}else {
				if(curShop != b.selectShop){
				b.selected = false;
				} else{
					b.chose = true;
				}
			}
		}
	}
}
