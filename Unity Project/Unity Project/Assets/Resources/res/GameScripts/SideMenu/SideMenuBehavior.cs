using UnityEngine;
using System.Collections;

public class SideMenuBehavior : MonoBehaviour
{

		public bool isOut;
	public bool isIn;
		public bool isSlidingIn;
		public bool isSlidingOut;
		Vector3 curPos;
	GUIText[] curGuiTexts;
	GameObject curSpriteRend;
	
		void Awake ()
		{
				DontDestroyOnLoad (gameObject);
		}

		// Use this for initialization
		void Start ()
	{
		curGuiTexts = GameObject.FindObjectsOfType<GUIText>();
		curSpriteRend = GameObject.FindGameObjectWithTag ("Textures");
		curPos = transform.position;
		transform.position = new Vector3 (-13f, curPos.y, curPos.z);
		isOut = false;
		isIn = true;
		isSlidingIn = false;
		isSlidingOut = false;
		}
	
		void Update ()
		{
		curPos = transform.position;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isOut) {
				isSlidingIn = true;
			} else {
				if (Application.loadedLevelName == "Main") {
					Application.Quit();
				} else {
					Application.LoadLevel("Main");
				}
				
			}
		}

				if (isSlidingIn) {
						slideIn ();
				}
				if (isSlidingOut) {
						slideOut ();
				}
		}

		void slideIn ()
	{
		isOut = false;
				transform.position = new Vector3 ((curPos.x - 0.5f), curPos.y, curPos.z);
		
		if (curGuiTexts != null) {
			fadeInText ();
		}
		if (curSpriteRend != null) {
			fadeInTextures ();
		}
		offColliders ();
		
				if (curPos.x < -13f) {
			transform.position = new Vector3 (-13f, curPos.y, curPos.z);
			isOut = false;
			isIn = true;
			isSlidingIn = false;
				}
		}

		void slideOut ()
	{
		isIn = false;
				transform.position = new Vector3 ((curPos.x + 0.5f), curPos.y, curPos.z);
			if (curGuiTexts != null) {
						fadeOutText ();
				}
			if (curSpriteRend != null) {
						fadeOutTextures ();
				}
		offColliders ();
				if (curPos.x > -3f) {
			transform.position = new Vector3 (-3f, curPos.y, curPos.z);
			isIn = false;
			isOut = true;
			isSlidingOut = false;
			onColliders ();
				}
		}

	void fadeInText() {
		if(curGuiTexts != null) {
		foreach (GUIText text in curGuiTexts) {
			float r = text.color.r;
			float g = text.color.g;
			float b = text.color.b;
			float a = text.color.a;
			if (a < 1f){
				text.color = new Color(r,g,b,(a+0.1f));
			}else {
				text.color = new Color(r,g,b,1f);
				 }
			}
				}
	}
	
	void fadeOutText() {
		if (curGuiTexts != null) {
						foreach (GUIText text in curGuiTexts) {
								float r = text.color.r;
								float g = text.color.g;
								float b = text.color.b;
								float a = text.color.a;
								if (a > 0.1f) {
										text.color = new Color (r, g, b, (a - 0.1f));
								} else {
										text.color = new Color (r, g, b, 0.1f);
								}
						}
				}
	}

	
	void fadeInTextures() {
		SpriteRenderer[] allSprites = curSpriteRend.GetComponentsInChildren<SpriteRenderer> ();
		if (allSprites != null) {
						foreach (SpriteRenderer sprite in allSprites) {
								float r = sprite.color.r;
								float g = sprite.color.g;
								float b = sprite.color.b;
								float a = sprite.color.a;
								if (a < 1f) {
										sprite.color = new Color (r, g, b, (a + 0.1f));
								} else {
										sprite.color = new Color (r, g, b, 1f);
								}
						}
				}
	}
	
	void fadeOutTextures() {
		SpriteRenderer[] allSprites = curSpriteRend.GetComponentsInChildren<SpriteRenderer> ();
		if (allSprites != null) {
						foreach (SpriteRenderer sprite in allSprites) {
								float r = sprite.color.r;
								float g = sprite.color.g;
								float b = sprite.color.b;
								float a = sprite.color.a;
								if (a > 0.3f) {
										sprite.color = new Color (r, g, b, (a - 0.1f));
								} else {
										sprite.color = new Color (r, g, b, 0.3f);
								}
						}
				}
	}

	void OnLevelWasLoaded() {
		isSlidingIn=true;
		curGuiTexts = GameObject.FindObjectsOfType<GUIText>();
		curSpriteRend = GameObject.FindGameObjectWithTag ("Textures");
	}

	void offColliders() {
		foreach (BoxCollider2D col in GetComponentsInChildren<BoxCollider2D> ()) {
			
			col.enabled = false;
		}
	}

	void onColliders() {
		foreach (BoxCollider2D col in GetComponentsInChildren<BoxCollider2D> ()) {
		         
						col.enabled = true;
				}
	}
}

