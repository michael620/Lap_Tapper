using UnityEngine;
using System.Collections;

public class CashInButton : MonoBehaviour {
	Playerstats playerStats;
	AudioSource sound;
	Animator anim;
	// Use this for initialization
	void Start () {
		playerStats = GameObject.Find("PlayerState").GetComponent<Playerstats>();
		sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
	}

	IEnumerator playSound() {
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
	}
	IEnumerator playAnim() {
		anim.SetTrigger ("Pressed");
		yield return new WaitForSeconds(anim.playbackTime);
	}

	void OnMouseDown() {
		StartCoroutine(playSound ());
		StartCoroutine(playAnim ());
		int newLapCoin = Mathf.FloorToInt(playerStats.blitzscore*1.2f + playerStats.lapCoin);
		playerStats.lapCoin = newLapCoin;
		sendscore (playerStats.blitzscore);
		playerStats.blitzscore = 0;
		playerStats.save ();

		Application.LoadLevel ("Blitz");
	}

	void sendscore (int x) {
		Social.ReportScore (x, "CgkIo8WN598OEAIQDQ", (bool success) => {
		});
	}
}
