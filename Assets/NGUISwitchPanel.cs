using UnityEngine;
using System.Collections;

[AddComponentMenu("NGUI/Interaction/Switch Menu AB")]
public class NGUISwitchPanel : MonoBehaviour {
	
	public GameObject currentPanelObject;
	public GameObject nextPanelObject;
	
	void OnClick() {
		NGUITools.SetActive(nextPanelObject, true);
		NGUITools.SetActive(currentPanelObject, false);
	}
	
}