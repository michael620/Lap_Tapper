using UnityEngine;
using System.Collections;

public class ButtonSkinChooser : MonoBehaviour {
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
		pSkins = PlayerPrefs.GetString ("bButtonSkins");
		availSkins = Resources.LoadAll<Sprite> ("res/Textures/Default/Shop/BasicColorSkin");
		if (skinIndex != -1) {
						gameObject.GetComponent<SpriteRenderer> ().sprite = availSkins [25];
						if (pSkins.Contains (skin)) {
								hasSkin = true;
								gameObject.transform.Find ("SkinSample").GetComponent<SpriteRenderer> ().sprite = availSkins [(skinIndex - 11)];
						} else {
								gameObject.transform.Find ("SkinSample").GetComponent<SpriteRenderer> ().sprite = availSkins [(skinIndex)];
						}
				} else {
			hasSkin = true;
		}
	}

		void OnMouseDown() {
				if (hasSkin) {
			PlayerPrefs.SetString ("cButtonSkin", "Default");
			PlayerPrefs.SetString ("cButtonColor", skin);
		} else {
						int lapCoin = PlayerPrefs.GetInt ("pLapCoin");
						if (lapCoin >= cost) {
								PlayerPrefs.SetInt ("pLapCoin", (lapCoin - cost));
								PlayerPrefs.SetString ("bButtonSkins", (pSkins + skin + " "));
				PlayerPrefs.SetString ("cButtonColor", skin);
				PlayerPrefs.SetString ("cButtonSkin", "Default");
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
		pSkins = PlayerPrefs.GetString ("bButtonSkins");
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
