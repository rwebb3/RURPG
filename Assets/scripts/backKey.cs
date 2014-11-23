using UnityEngine;
using System.Collections;

public class backKey : MonoBehaviour {

	public bool exitProgram;
	public GameObject currentPanelObject;
	public GameObject previousPanelObject;
	
	void OnClick () {
		if (exitProgram) {Application.Quit ();}
		else {
			NGUITools.SetActive(previousPanelObject, true);
			NGUITools.SetActive(currentPanelObject, false);
		}
	}
	// Update is called once per frame
	void Update () {
		//code makes back buttons on Android devices work
		if (Application.platform == RuntimePlatform.Android)
		{
			if ( Input.GetKey(KeyCode.Escape) && currentPanelObject.activeInHierarchy)
			{
				if (exitProgram ) {Application.Quit();}
				else {
					NGUITools.SetActive(previousPanelObject, true);
					NGUITools.SetActive(currentPanelObject, false);
				}

			}
		}
	}
}
