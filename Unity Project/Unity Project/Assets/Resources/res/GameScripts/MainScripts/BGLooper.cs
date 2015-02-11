using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public int numPanels;
	Playerstats player;
	string curBG;
	Sprite[] BG;
	int numBG;

	void Start() {
		player = GameObject.Find ("PlayerState").GetComponent<Playerstats> ();
	}

	void Update(){
		if (player.curBG != curBG) {
						curBG = player.curBG;
			BG = Resources.LoadAll<Sprite>("res/Textures/Default/BG/" +curBG+ "/bg");
			numBG = BG.Length;
				}
		}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log (collider);
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x -= widthOfBGObject * numPanels;

		collider.transform.position = pos;

		int rand = Mathf.RoundToInt (Random.Range (0, numBG - 1));

		collider.gameObject.GetComponent<SpriteRenderer> ().sprite = BG [rand];
	}
}
