using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class SplashScreenLoad : MonoBehaviour {
	bool loaded;
	bool toDestroy;
	// Use this for initialization
	void Start () {
		loaded = false;
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource> ().Play ();

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (!loaded) {
			loaded = true;
			StartCoroutine (splashLoad ());
				}
		if ((Application.loadedLevelName != "SplashScreen")&&(GameObject.FindGameObjectWithTag ("MainCamera") != null)) {
						toDestroy = true;
				}
		if (toDestroy&&loaded) {
			Destroy(gameObject);
				}
	}

	IEnumerator splashLoad() {
		if (PlayerPrefs.GetInt ("finishedTut") == 1) {
			Application.LoadLevel ("Main");
			yield return new WaitForSeconds (1f);
		} else {
			Application.LoadLevel ("Tutorial");
			toDestroy = true;
			yield return new WaitForSeconds (1f);
		}
		}
}
