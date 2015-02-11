using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class AchievementButtonBehavior : MonoBehaviour {
	
	AudioSource sound;
	Animator anim;
	
	void Start () {
		sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		
	}
	void OnMouseDown() {
		StartCoroutine (showAchievements ());
	}

	IEnumerator showAchievements() {
		sound.Play ();
		yield return new WaitForSeconds(sound.clip.length);
		anim.SetTrigger ("Pressed");
		yield return new WaitForSeconds(anim.playbackTime);
		Social.ShowAchievementsUI ();
	}
}
