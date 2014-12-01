using UnityEngine;
using System.Collections;

public class MapLoadLevel : MonoBehaviour {
	public string level;
	public string promptText;
	public Font labelFont;
	public GameObject checkMark;

	private GUIStyle dialogLabelStyle, dialogButtonStyle;
	// 200x300 px window will apear in the center of the screen.
	private Rect windowRect = new Rect((Screen.width*.25f) , (Screen.height*.25f), (Screen.width/2f), (Screen.height/6f));
	// Only show it if needed.
	private bool show = false;
	private bool firstClickChecked = false;
	private Vector3 firstClick;
	void Start(){
		foreach(Level l in GameData.current.levels){
			if (l.name.Equals(level)){
				Debug.Log(l.name);
				if (l.isComplete){
					checkMark.renderer.enabled = true;}
			}
		}
	}
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
		//Debug.Log (dialogLabelStyle.fontSize);
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
	public void Open()
	{
		show = true;
	}

	void checkToOpen(Vector3 worldPoint){
		Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
		//Debug.Log(touchPos);
		//Debug.Log(Input.mousePosition);
		if (collider2D.OverlapPoint(touchPos)){
			Open();
		}
	}

	// Update is called once per frame
	void Update() {
	/*if (Application.platform == RuntimePlatform.Android){
		if (Input.touchCount == 1){
			checkToOpen((Vector3)Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
		}
	}
	else{*/
			if (Input.GetMouseButton(0)){
				if (!firstClickChecked){
					firstClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					//Debug.Log("first: "+firstClick);
					firstClickChecked = true;
				}
			}
			if (Input.GetMouseButtonUp(0)){
				Vector3 endClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//Debug.Log("end: " + endClick);
				if (firstClick == endClick){
					checkToOpen(endClick);
				}
				firstClickChecked = false;
			}
		//}
	}

}
