using UnityEngine;
using System.Collections;

public class MainAudio : MonoBehaviour {
	AudioSource music;

	void Start() {
		music = gameObject.GetComponent<AudioSource> ();
		if(Application.loadedLevel == 4){
			music.clip = (AudioClip)Resources.Load("res/Sounds/Blitz");
			music.loop = true;
			music.Play();
		}
		}

	void Awake() {
		DontDestroyOnLoad (gameObject);
	}
	void Update() {
		if (AudioListener.volume == 0) {
			Destroy(gameObject);
				}
	}
	void OnLevelWasLoaded(int i) {
		if (i == 4) {
						music.clip = (AudioClip)Resources.Load ("res/Sounds/Blitz");
			music.volume = 0.5f;
						music.loop = true;
						music.Play ();
				} else {
						if (music.clip != (AudioClip)Resources.Load ("res/Sounds/Main")) {
				music.clip = (AudioClip)Resources.Load ("res/Sounds/Main");
				music.volume = 1f;
								music.loop = true;
								music.Play ();

						}
				}
	}
}
