using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class FirstTimePlaying : MonoBehaviour {
	
	GameObject circle;
	GameObject[] laps; 
	GameObject[] reset;
	GameObject welcome;
	public byte pr;
	public byte pg;
	public byte pb;
	public byte inc;
	bool hasCircle;
	bool hasLaps;
	bool hasReset;
	bool isMouseDown = false;
	bool hasWelcomed;
	bool hasLapTut;
	bool hasClearedTut;
	float scale;
	
	// Use this for initialization
	void Start () {
		
		scale = Screen.width / 375f; //your scale
		
		circle = GameObject.FindGameObjectWithTag ("Circle");
		welcome = GameObject.FindGameObjectWithTag ("Welcome");
		
		reset = GameObject.FindGameObjectsWithTag ("Reset");
		laps = GameObject.FindGameObjectsWithTag ("Laps");
		
		Color32 tp = new Color32 (pr, pg, pb, 0);
		
		circle.GetComponent<SpriteRenderer> ().color = tp;
		welcome.GetComponent<GUIText> ().color = tp;
		
		foreach (GameObject ob in reset) {
			if (ob.GetComponent<GUIText>() != null){
				ob.GetComponent<GUIText>().color = tp;
			}
			if (ob.GetComponent<SpriteRenderer> () != null) {
				ob.GetComponent<SpriteRenderer> ().color = tp;
			}
		}
		foreach (GameObject ob in laps) {
			if (ob.GetComponent<GUIText>() != null){
				ob.GetComponent<GUIText>().color = tp;
			}
			if (ob.GetComponent<SpriteRenderer> () != null) {
				ob.GetComponent<SpriteRenderer> ().color = tp;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		showCircle ();
		isMouseDown = false;
		if (hasCircle) {
			if(!hasWelcomed){
				isMouseDown = Input.GetMouseButtonDown(0);
				showWelcome();
			}
			else {
				showLaps();
			}
		}
		if (hasLaps&&(!hasLapTut)) {
			hasCircle = false;
			isMouseDown = Input.GetMouseButtonDown(0);
			showLapsTut();
			
		}
		if (hasLapTut) {
			showReset();
		}
		if (hasReset&&(!hasClearedTut)) {
			hasCircle = false;
			hasLaps = false;
			isMouseDown = Input.GetMouseButtonDown(0);
			showResetTut();
			
		}
		
		if (hasClearedTut) {
			PlayerPrefs.SetInt("finishedTut",1);
			Social.ReportProgress("CgkIo8WN598OEAIQAQ", 100.0f, (bool success) => {
				// handle success or failure
			});
			Application.LoadLevel ("EndOfTutorial");
		}
		
	}
	
	void showCircle() {
		
		if (circle.GetComponent<SpriteRenderer> ().color.a < 1f) {
			float tempa = circle.GetComponent<SpriteRenderer> ().color.a;
			byte tempb;
			tempb = (byte)(tempa * 255);
			if (tempb > (255 - inc)) {
				tempb = (byte)(255 - inc);
			}
			Color32 ctemp = new Color32 (pr, pg, pb, (byte)(tempb + inc));
			circle.GetComponent<SpriteRenderer> ().color = ctemp;
		} else {
			hasCircle = true;
		}
	}
	
	void showLaps() {
		foreach (GameObject ob in laps) {
			if (ob.GetComponent<GUIText>() != null){
				if (ob.GetComponent<GUIText> ().color.a < 1f){
					hasLaps = false;
				}else {
					hasLaps = true;
				}
				float tempa = ob.GetComponent<GUIText>().color.a;
				byte tempc;
				tempc = (byte)(tempa * 255);
				if (tempc > (255 - inc)) {
					tempc = (byte)(255 - inc);
				}
				Color32 ctempa = new Color32 (pr, pg, pb, (byte)(tempc + inc));
				ob.GetComponent<GUIText>().color = ctempa;
			}
			if (ob.GetComponent<SpriteRenderer> () != null) {
				float tempb = ob.GetComponent<SpriteRenderer> ().color.a;
				byte tempc;
				tempc = (byte)(tempb * 255);
				if (tempc > (255 - inc)) {
					tempc = (byte)(255 - inc);
				}
				Color32 ctempb = new Color32 (255, 255, 255, (byte)(tempc + inc));
				ob.GetComponent<SpriteRenderer>().color = ctempb;
			}
		}
		
		
	}
	
	void showWelcome() {
		if (!isMouseDown) {
			float tempa = welcome.GetComponent<GUIText> ().color.a;
			byte tempc;
			tempc = (byte)(tempa * 255);
			if (tempc > (255 - inc)) {
				tempc = (byte)(255 - inc);
			}
			Color32 ctempa = new Color32 (pr, pg, pb, (byte)(tempc + inc));
			
			welcome.GetComponent<GUIText> ().color = ctempa;
		} else {
			welcome.GetComponent<GUIText> ().color = new Color (pr, pg, pb, 0f);
			hasWelcomed = true;
			welcome.GetComponent<GUIText>().text = "Tap Lap Button \n to lap";
			float tempy = welcome.GetComponent<GUIText>().transform.position.y - 0.22f;
			float tempx = welcome.GetComponent<GUIText>().transform.position.x;
			float tempz = welcome.GetComponent<GUIText>().transform.position.z;
			
			Vector3 newPos = new Vector3(tempx,tempy,tempz);
			welcome.GetComponent<GUIText>().transform.position= newPos;
			welcome.GetComponent<GUIText>().fontSize = Mathf.RoundToInt (30*scale);
			
		}
		
	}
	void showLapsTut(){
		
		if (!isMouseDown) {
			float tempa = welcome.GetComponent<GUIText> ().color.a;
			byte tempc;
			tempc = (byte)(tempa * 255);
			if (tempc > (255 - inc)) {
				tempc = (byte)(255 - inc);
			}
			Color32 ctempa = new Color32 (pr, pg, pb, (byte)(tempc + inc));
			
			welcome.GetComponent<GUIText> ().color = ctempa;
		} else {
			welcome.GetComponent<GUIText> ().color = new Color (pr, pg, pb, 0f);
			welcome.GetComponent<GUIText>().text = "Reset Button will \n reset your score.";
			welcome.GetComponent<GUIText>().fontSize = Mathf.RoundToInt (25*scale);
			float tempy = welcome.GetComponent<GUIText>().transform.position.y + 0.03f;
			float tempx = welcome.GetComponent<GUIText>().transform.position.x;
			float tempz = welcome.GetComponent<GUIText>().transform.position.z;
			
			Vector3 newPos = new Vector3(tempx,tempy,tempz);
			welcome.GetComponent<GUIText>().transform.position= newPos;
			
			hasLapTut = true;
		}
	}
	void showReset() {
		foreach (GameObject ob in reset) {
			if (ob.GetComponent<SpriteRenderer>() != null){
				if (ob.GetComponent<SpriteRenderer> ().color.a < 1f){
					hasReset = false;
				}else {
					hasReset = true;
				}
				float tempa = ob.GetComponent<SpriteRenderer>().color.a;
				byte tempc;
				tempc = (byte)(tempa * 255);
				if (tempc > (255 - inc)) {
					tempc = (byte)(255 - inc);
				}
				Color32 ctempa = new Color32 (255, 255, 255, (byte)(tempc + inc));
				ob.GetComponent<SpriteRenderer>().color = ctempa;
			}
		}
		
		
	}
	
	void showResetTut() {
		if (!isMouseDown) {
			float tempa = welcome.GetComponent<GUIText> ().color.a;
			byte tempc;
			tempc = (byte)(tempa * 255);
			if (tempc > (255 - inc)) {
				tempc = (byte)(255 - inc);
			}
			Color32 ctempa = new Color32 (pr, pg, pb, (byte)(tempc + inc));
			
			welcome.GetComponent<GUIText> ().color = ctempa;
		} else {
			welcome.GetComponent<GUIText> ().color = new Color (pr, pg, pb, 0f);
			hasClearedTut = true;
			
		}
		
	}
	
}
