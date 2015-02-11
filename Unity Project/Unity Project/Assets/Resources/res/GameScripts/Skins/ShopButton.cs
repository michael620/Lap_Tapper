using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {
	public string selectShop;

	public bool selected;

	public bool chose;

	GameObject shop;

	Sprite[] buttonSp;

	// Use this for initialization
	void Start () {
		shop = GameObject.Find (selectShop);
		buttonSp = Resources.LoadAll<Sprite>("res/Textures/Default/Shop/BasicColorSkin");
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
						shop.SetActive(true);
			GetComponent<SpriteRenderer>().sprite = buttonSp[27];
			gameObject.transform.FindChild("Text").GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,1f);
			Vector3 v = transform.position;
			transform.position = new Vector3(v.x,v.y,0);
			chose = false;
				} else {
			GetComponent<SpriteRenderer>().sprite = buttonSp[26];
			gameObject.transform.FindChild("Text").GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			shop.SetActive(false);
			Vector3 v = transform.position;
			transform.position = new Vector3(v.x,v.y,3);
				}
	
	}

	void OnMouseDown () {
		chose = true;
	}
}
