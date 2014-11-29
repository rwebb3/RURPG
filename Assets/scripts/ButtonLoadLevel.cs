using UnityEngine;
using System.Collections;

public class ButtonLoadLevel : MonoBehaviour {
	public string level;
	public string promptText;
	public GUIStyle dialogLabelStyle;
	// 200x300 px window will apear in the center of the screen.
	private Rect windowRect = new Rect((Screen.width*.25f) , (Screen.height*.25f), (Screen.width/2f), (Screen.height/6f));
	// Only show it if needed.
	private bool show = false;

	
	void OnGUI () 
	{
		if(show)
			windowRect = GUI.Window (0, windowRect, DialogWindow, "");
	}
	
	// This is the actual window.
	void DialogWindow (int windowID)
	{
		GUI.Label(new Rect(windowRect.width/50, windowRect.height/8, windowRect.width, windowRect.height/3), promptText, dialogLabelStyle);
		
		if(GUI.Button(new Rect(windowRect.width/8, windowRect.height/2, windowRect.width/2-windowRect.width/8, windowRect.height/3), "Yes"))
		{
			Application.LoadLevel(level);
			show = false;
		}
		
		if(GUI.Button(new Rect(windowRect.width/2+5, windowRect.height/2, windowRect.width/2-windowRect.width/8, windowRect.height/3), "No"))
		{
			show = false;
		}
	}
	
	// To open the dialogue from outside of the script.
	public void Open()
	{
		show = true;
	}
	void OnClick(){
		Open();
	}
}