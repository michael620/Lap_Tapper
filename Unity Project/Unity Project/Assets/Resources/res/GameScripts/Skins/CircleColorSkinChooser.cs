using UnityEngine;
using System.Collections;

public class CircleColorSkinChooser : MonoBehaviour {
	public string skin;
	public bool hasSkin = false;
	bool isSelected = false;
	public bool choseSkin;
	string pSkins;
	public int skinIndex;
	Sprite[] availSkins;
	public int cost;
	// Use this for initialization
	void Start () {
		pSkins = PlayerPrefs.GetString ("bCircleSkins");
		availSkins = Resources.LoadAll<Sprite> ("res/Textures/Default/Shop/BasicColorSkin");
		if (skinIndex != -1) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = availSkins [25];
			if (pSkins.Contains (skin)) {
				hasSkin = true;
				gameObject.transform.Find ("SkinSample").GetComponent<SpriteRenderer> ().sprite = availSkins [(skinIndex - 11)];
			} else {
				gameObject.transform.Find ("SkinSample").GetComponent<SpriteRenderer> ().sprite = availSkins [(skinIndex)];
			}
		}
	}
	
	void OnMouseDown() {
		if (hasSkin) {
			PlayerPrefs.SetString ("cCircleColor", skin);
			PlayerPrefs.SetString ("cCircleSkin", "Default");
		} else {
			int lapCoin = PlayerPrefs.GetInt ("pLapCoin");
			if (lapCoin >= cost) {
				PlayerPrefs.SetInt ("pLapCoin", (lapCoin - cost));
				PlayerPrefs.SetString ("bCircleSkins", (pSkins + skin + " "));
				PlayerPrefs.SetString ("cCircleSkin", "Default");
				PlayerPrefs.SetString ("cCircleColor", skin);
				if(skinIndex != -1) {
					gameObject.transform.Find ("SkinSample").GetComponent<SpriteRenderer> ().sprite = availSkins [(skinIndex - 11)];
				}
				hasSkin = true;
			} else {
				StartCoroutine(select());
			}
		}
	}
	
	IEnumerator select (){
		GetComponent<SpriteRenderer>().sprite = availSkins[24];
		yield return new WaitForSeconds (0.02f);
		GetComponent<SpriteRenderer>().sprite = availSkins[25];
		
	}
	
	// Update is called once per frame
	void Update () {
		pSkins = PlayerPrefs.GetString ("bCircleSkins");
		if (choseSkin && (!isSelected)) {
			GetComponent<SpriteRenderer>().sprite = availSkins[24];
			isSelected = true;
		}
		if ((!choseSkin) && isSelected) {
			GetComponent<SpriteRenderer>().sprite = availSkins[25];
			isSelected = false;
		}
	}
}
