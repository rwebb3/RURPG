using UnityEngine;
using System.Collections;

public class ExitStage : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		//if the thing that entered was the player, change the sprite to the opened door.
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			Debug.Log("hi");
			//this.GetComponent<SpriteRenderer>().sprite = openedDoor;
			Application.LoadLevel("map");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
