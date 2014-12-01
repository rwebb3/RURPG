using UnityEngine;
using System.Collections;

public class movePanel : MonoBehaviour {
	//float horizontalSpeed = 0.048f;
	//float verticalSpeed = 0.048f;

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")){
		transform.Translate ((Input.GetAxis("Mouse X")),
		                     (Input.GetAxis("Mouse Y")),
		                     0.0f);
		}
	}

}

