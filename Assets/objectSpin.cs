using UnityEngine;
using System.Collections;

public class objectSpin : MonoBehaviour { 
	public float speed;

	private bool playerIsNear = false; 

	void OnTriggerStay2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			playerIsNear = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			this.transform.localEulerAngles = new Vector3(0,0,-45);
			playerIsNear = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerIsNear){
			this.transform.RotateAround(this.transform.position, Vector3.up, Time.deltaTime * speed);
			}
	}
}
