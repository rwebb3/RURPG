using UnityEngine;
using System.Collections;

public class SetToPlayerPos : MonoBehaviour {
	private Vector3 screenPos;
	private bool display = false;

	public Transform target;

	public GUIContent content;
	public int width;
	public int height;
	
	// Update is called once per frame

	void OnGUI(){
		this.transform.position = target.position;
	}
}
