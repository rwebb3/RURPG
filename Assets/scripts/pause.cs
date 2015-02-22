using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
	private bool paused = false;
	public Font labelFont;
	
	private GUIStyle dialogLabelStyle, dialogButtonStyle;
	// 200x300 px window will apear in the center of the screen.
	private Rect windowRect = new Rect((Screen.width*.25f) , (Screen.height*.25f), (Screen.width/2f), (Screen.height/6f));
	// Only show it if needed.
	private bool show = false;
	
	void OnGUI () 
	{
		
		dialogLabelStyle = new GUIStyle();
		dialogLabelStyle.font = labelFont;
		dialogLabelStyle.normal.textColor = Color.white;
		dialogLabelStyle.alignment = TextAnchor.UpperCenter;
		
		dialogButtonStyle = new GUIStyle(GUI.skin.button);
		
		
		if(show){
			windowRect = GUI.Window (0, windowRect, DialogWindow, "");
			dialogLabelStyle.fontSize = (int)windowRect.height/6;
			dialogButtonStyle.fontSize = (int)windowRect.height/8;
		}
	}
	
	// This is the actual window.
	void DialogWindow (int windowID)
	{
		
		GUI.Label(new Rect(windowRect.width/50, windowRect.height/8, windowRect.width, windowRect.height/3), "Paused", dialogLabelStyle);
		//Debug.Log (dialogLabelStyle.fontSize);
		/*if(GUI.Button(new Rect(windowRect.width/8, windowRect.height/2, windowRect.width/2-windowRect.width/8, windowRect.height/3), "Yes", dialogButtonStyle))
		{
			paused = false;
			show = false;
			Time.timeScale = 1;
			
		}*/
		
		if(GUI.Button(new Rect(windowRect.width/16, windowRect.height/2, windowRect.width-windowRect.width/8, windowRect.height/3), "Resume", dialogButtonStyle))
		{
			paused = false;
			show = false;
			Time.timeScale = 1;
		}
	}
	
	// To open the dialogue from outside of the script.
	public void Open()
	{
		show = true;
	}

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per tick
	void FixedUpdate() {
		if (Input.GetKey(KeyCode.Escape)){
				show = true;
				paused = true;
		}
		if (paused){
			Time.timeScale = 0;
		}			
	}
}
