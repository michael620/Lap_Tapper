using UnityEngine;
using System.Collections;

public class AchievementReport : MonoBehaviour {

	int aut;
	Playerstats player;
	LapButtonBlitz blitzButton;
	GameObject lapCoin;
	public string curLevel;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		player = GameObject.Find("PlayerState").GetComponent<Playerstats> ();
		blitzButton = GameObject.Find ("GraphicManager/LapButton").GetComponent<LapButtonBlitz> ();
		lapCoin = GameObject.Find ("GraphicManager/LapCoins/AchievementText");
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
						player = GameObject.Find ("PlayerState").GetComponent<Playerstats> ();
				} else {
			if (Application.loadedLevelName == "Main") {
				if (curLevel != "Main") {
					curLevel = "Main";
				}
								reportLapScore ();
						}
			if (Application.loadedLevelName == "Blitz") {
				if (curLevel != "Blitz") {
					blitzButton = GameObject.Find ("GraphicManager/LapButton").GetComponent<LapButtonBlitz> ();
					Debug.Log("Found Button");
					curLevel = "Blitz";
				}
								reportBlitz ();
						}
		
						if (lapCoin == null) {
				lapCoin = GameObject.Find ("GraphicManager/LapCoins/AchievementText");
						}
				}
	}
	void reportLapScore() {
		int score = player.score;
		if ((score >= 100)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" a,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQAg", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("a");
					StartCoroutine(displayGains("+100"));
					player.lapCoin += 100;
					}
				});
			}
		}
		
		if ((score >= 500)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" b,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQAw", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("b");
					StartCoroutine(displayGains("+100"));
					player.lapCoin += 100;
					}
				});
			}
		}
		
		if ((score >= 1000)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" c,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQBA", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("c");
					StartCoroutine(displayGains("+100"));
					player.lapCoin += 100;
					}
				});
			}
		}
		
		if ((score >= 2500)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" d,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQBQ", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("d");
					StartCoroutine(displayGains("+300"));
					player.lapCoin += 300;
					}
				});
			}
		}
		
		if ((score >= 5000)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" e,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQBg", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("e");
					StartCoroutine(displayGains("+300"));
					player.lapCoin += 300;
					}
				});
			}
		}
		
		if ((score >= 9000)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" f,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQBw", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("f");
					StartCoroutine(displayGains("+300"));
					player.lapCoin += 300;
					}
				});
			}
		}
		
		if ((score >= 10000)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" g,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQCA", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("g");
					StartCoroutine(displayGains("+500"));
					player.lapCoin += 500;
					}
				});
			}
		}
		
		if ((score >= 25000)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" h,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQCQ", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("h");
					StartCoroutine(displayGains("+500"));
					player.lapCoin += 500;
					}
				}); 
			}
		}
		
		if ((score >= 50000)) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" i,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQCg", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("i");
					StartCoroutine(displayGains("+1000"));
					player.lapCoin += 1000;
					}
				});
			}
		}
		
		if ((score >= 100000)) {
		}
		
		if (score >= 1000000) {
		}
	}

	void reportBlitz() {
		int blitzscore = player.blitzscore;
		if (blitzButton.done) {

						if ((blitzscore >= 100)) {
				if (!PlayerPrefs.GetString("uAchievements").Contains(" j,")) {
					Social.ReportProgress ("CgkIo8WN598OEAIQEA", 100.0f, (bool success) => {
						if (success) {
							saveAchievement("j");
						StartCoroutine(displayGains("+500"));
						player.lapCoin += 500;
						}
										});
								}
						}
						if ((blitzscore >= 150)) {
				if (!PlayerPrefs.GetString("uAchievements").Contains(" k,")) {
					Social.ReportProgress ("CgkIo8WN598OEAIQEQ", 100.0f, (bool success) => {
						if (success) {
							saveAchievement("k");
						StartCoroutine(displayGains("+1000"));
						player.lapCoin += 1000;
						}
										});
								}
						}
				}
	}

	IEnumerator displayGains(string str) {
		lapCoin.GetComponent<GUIText> ().text = str;
		Color c = lapCoin.GetComponent<GUIText> ().color;
		c.a = 1f;
		lapCoin.GetComponent<GUIText> ().color = c;
		yield return new WaitForSeconds (2f);
		c.a = 0f;
		lapCoin.GetComponent<GUIText> ().text = "";
		lapCoin.GetComponent<GUIText> ().color = c;
		}

	void saveAchievement(string acv) {
		string newAchievements = PlayerPrefs.GetString ("uAchievements") +" "+ acv + ", ";
		PlayerPrefs.SetString ("uAchievements", newAchievements);
		}

	void OnLevelWasLoaded(int i) {
		if ((PlayerPrefs.GetString ("cButtonSkin") != "Default") && (PlayerPrefs.GetString ("cButtonSkin") != "")) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" l,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQDw", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("l");
					}
					// handle success or failure
				});
			}
		}

		if ((PlayerPrefs.GetString ("cCircleSkin") != "Default") && (PlayerPrefs.GetString ("cCircleSkin") != "")) {
			if (!PlayerPrefs.GetString("uAchievements").Contains(" m,")) {
				Social.ReportProgress ("CgkIo8WN598OEAIQDg", 100.0f, (bool success) => {
					if (success) {
						saveAchievement("l");
					}
				// handle success or failure
				});
		}
	}
		}

}
