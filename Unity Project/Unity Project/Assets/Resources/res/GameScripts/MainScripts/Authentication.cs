using UnityEngine;
using System.Collections;

public class Authentication : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		Social.localUser.Authenticate((bool success) => {
			if(success) {
				Destroy(gameObject);
			}
			
			
		});
		}
}
