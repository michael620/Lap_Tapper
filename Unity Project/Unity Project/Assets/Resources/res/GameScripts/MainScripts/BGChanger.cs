using UnityEngine;
using System.Collections;

public class BGChanger : MonoBehaviour {
	Playerstats player;
	string setBG;
	public string[] bg;
	int countLap;
	int curLap;

	public float unlockNum;

	// Use this for initialization
	void Start () {
		setBG = PlayerPrefs.GetString ("cBG", "City");
		player = GameObject.Find ("PlayerState").GetComponent<Playerstats> ();
		countLap = player.score;
		player.curBG = setBG;
	}
	
	// Update is called once per frame
	void Update () {
		curLap = player.score;
		if ((Mathf.Abs (curLap - countLap)) >= 500) {
			countLap = curLap;

						if (player.curBG == setBG) {
								changeBackground ();
						}
				}
	}
	
	void changeBackground ()
	{
		int rand = Mathf.RoundToInt (Random.Range (0, unlockNum - 1));
		setBG = bg[rand];
		player.curBG = setBG;
		PlayerPrefs.SetString ("cBG", setBG);
	}
}
