using UnityEngine;
using System.Collections;

public class ReturnToMenu : MonoBehaviour {
	public string level;
	public string promptText;
	public Font labelFont;
	
	private GUIStyle dialogLabelStyle, dialogButtonStyle;
	// 200x300 px window will apear in the center of the screen.
	private Rect windowRect = new Rect((Screen.width*.25f) , (Screen.height*.25f), (Screen.width/2f), (Screen.height/6f));
	// Only show it if needed.
	private bool show = false;
	private bool firstClickChecked = false;
	private Vector3 firstClick;
	
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
		
		GUI.Label(new Rect(windowRect.width/50, windowRect.height/8, windowRect.width, windowRect.height/3), promptText, dialogLabelStyle);
		Debug.Log (dialogLabelStyle.fontSize);
		if(GUI.Button(new Rect(windowRect.width/8, windowRect.height/2, windowRect.width/2-windowRect.width/8, windowRect.height/3), "Yes", dialogButtonStyle))
		{
			Application.LoadLevel(level);
			show = false;
		}
		
		if(GUI.Button(new Rect(windowRect.width/2+5, windowRect.height/2, windowRect.width/2-windowRect.width/8, windowRect.height/3), "No", dialogButtonStyle))
		{
			show = false;
		}
	}
	
	// To open the dialogue from outside of the script.
	public void Open(){
		show = true;
	}

	void OnClick(){
		Open();
	}
	
}
