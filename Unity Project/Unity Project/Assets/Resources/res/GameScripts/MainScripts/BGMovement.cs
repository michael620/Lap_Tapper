using UnityEngine;
using System.Collections;

public class BGMovement : MonoBehaviour {

	Animator avatar;

	// Use this for initialization
	void Start () {
		avatar = GameObject.Find ("Avatar").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		int speed = avatar.GetInteger ("detAni");
		moveBG (speed);
	}

	void moveBG(int speed) {
		float scale = Mathf.Pow (speed, 2f);
		float time = Time.deltaTime;
		Vector3 pos = gameObject.transform.position;
		pos.x += (scale*time);
		gameObject.transform.position = pos;
	}
}
