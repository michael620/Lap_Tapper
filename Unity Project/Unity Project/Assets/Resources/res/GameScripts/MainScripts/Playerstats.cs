using UnityEngine;
using System.Collections;   
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Playerstats : MonoBehaviour
{

		public int score;
		public int resetsovern;
		public int playtime;
		public int lapCoin;
		float timer;
		public bool startedPlay;
		public string title;
		public int lpm;
		public float targetSecs;
		public float curSecs1;
		public float curSecs2;
	public float curSecs3;
	public float curSecs4;
		public int curLaps1;
		public int curLaps2;
	public int curLaps3;
	public int curLaps4;
		GameObject messages_go;
		public float numMessage;
		public float mesTime;
		float lastUpdatedTime;
		public bool isPlaying;
// Blitz Mode Variables
	public int blitzscore;
	public bool blitzStart;
	public int messageNumToDisplay;
	public string curBG;

		void Awake ()
		{
				startedPlay = true;
		}

		// Use this for initialization
		void Start ()
		{
				if (targetSecs == 0) {
						targetSecs = 0.7f;		
				}
				score = PlayerPrefs.GetInt ("pScore");
				lapCoin = PlayerPrefs.GetInt ("pLapCoin");
				resetsovern = PlayerPrefs.GetInt ("pReset");
				lastUpdatedTime = PlayerPrefs.GetFloat ("lastUpdatedTime");
				timer = PlayerPrefs.GetFloat ("pTime");
				title = PlayerPrefs.GetString ("pTitle");

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (startedPlay) {
						timer += Time.deltaTime;
						curSecs1 += Time.deltaTime;
						curSecs2 += Time.deltaTime;
			curSecs3 += Time.deltaTime;
			curSecs4 += Time.deltaTime;
						mesTime += Time.deltaTime;
						lastUpdatedTime += Time.deltaTime;
				}
				if (lastUpdatedTime > 300) {
						updateLeaderboard ();
						lastUpdatedTime = 0;
				}
				playtime = Mathf.FloorToInt (timer);
				detLPM ();
		}


		void detLPM ()
		{
				if (curSecs1 < targetSecs) {
						float mul = (45f);
						if (lpm == 0) {
								lpm = Mathf.FloorToInt (mul * curLaps1);
						}
						curLaps1 = 0;
						curSecs1 = 0;
				}
				if (curSecs2 >= (targetSecs)) {
						float mul = (60f / curSecs2);
						lpm = Mathf.FloorToInt (mul * curLaps2);
						curLaps2 = 0;
			curSecs2 = 0;
			save ();
				}
				if (curSecs3 >= (targetSecs * 2)) {
						float mul = (60f / curSecs3);
						lpm = Mathf.FloorToInt (mul * curLaps3);
						curLaps3 = 0;
						curSecs3 = 0;
		}
		if (curSecs4 >= (targetSecs * 3)) {
			float mul = (60f / curSecs4);
			lpm = Mathf.FloorToInt (mul * curLaps4);
			curLaps4 = 0;
			curSecs4 = 0;
		}
				if (mesTime >= (targetSecs * 5)) {
			
						int rand = Mathf.RoundToInt (Random.Range (0, numMessage - 1));

			messageNumToDisplay = rand;

						mesTime = 0;
				}

		}
	
		public void save ()
		{
				PlayerPrefs.SetInt ("pScore", score);
				PlayerPrefs.SetInt ("pReset", resetsovern);
				PlayerPrefs.SetFloat ("pTime", timer);
				PlayerPrefs.SetString ("pTitle", title);
				PlayerPrefs.SetFloat ("lastUpdatedTime", lastUpdatedTime);
				PlayerPrefs.SetInt ("pLapCoin", lapCoin);
		}

		public void updateLeaderboard ()
		{
				save ();
						Social.ReportScore (score, "CgkIo8WN598OEAIQAA", (bool success) => {
						});
						Social.ReportScore ((playtime * 1000), "CgkIo8WN598OEAIQDA", (bool success) => {
						});
				}
}
