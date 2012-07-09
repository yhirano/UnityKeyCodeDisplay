using UnityEngine;
using System;
using System.Collections;

public class KeyCodeDisplay : MonoBehaviour {
	
	private Rect viewPosition = new Rect();
	
	private Texture2D backgroundTexture = null;
	
	private GUIStyle guiStyle = null;
	
	private string viewText = string.Empty;
	
	void Start () {
		viewPosition.x = 8;
		viewPosition.y = 8;
		viewPosition.width = Screen.width - 16;
		viewPosition.height = Screen.height - 16;
	}
	
	void Update () {
		foreach(KeyCode code in Enum.GetValues(typeof(KeyCode))) {
			if (Input.GetKeyDown(code)) {
				viewText = "KeyDown " + code.ToString();
			} else if (Input.GetKeyUp(code)) {
				viewText = "KeyUp " + code.ToString();
			}
		}
	}
	
	void OnGUI() {
		if (backgroundTexture == null) {
			backgroundTexture = new Texture2D (1, 1);
			// Fill the texture.
			for (int y = 0; y < backgroundTexture.height; ++y) {
				for (int x  = 0; x < backgroundTexture.width; ++x) {
					backgroundTexture.SetPixel (x, y, new Color (0, 0, 0, 0.5F));
				}
			}
			// Apply all SetPixel calls
			backgroundTexture.Apply ();
		}
		
		if (guiStyle == null) {
			guiStyle = new GUIStyle();
			guiStyle.normal.textColor = new Color (0, 1, 0);
			guiStyle.normal.background = backgroundTexture;
		}
		
		GUI.Box (viewPosition, viewText, guiStyle);
	}
}
