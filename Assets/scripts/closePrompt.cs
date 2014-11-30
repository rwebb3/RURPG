using UnityEngine;
using System.Collections;

public class closePrompt : MonoBehaviour {

	public GameObject currentPanelObject;
	public GameObject filePanel;
	
	void OnClick() {
		NGUITools.SetActive(currentPanelObject, false);
		ActivateAllExcept(true, "FilePrompt");
	}

	void ActivateAllExcept(bool activate, string _except)
	{
		// this will get you all the colliders of all widgets under your panel - recursively
		Collider[] colliders = filePanel.GetComponentsInChildren<Collider>();
		foreach (Collider col in colliders)
			if (col.gameObject.tag != _except) // for this to work, names should be unique. I just used the name as an example, use whatever unique identifier you want...
				col.enabled = activate;
	}
}
