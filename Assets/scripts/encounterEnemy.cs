using UnityEngine;
using System.Collections;

public class encounterEnemy : MonoBehaviour {
	public GameObject mainObject;

	void OnTriggerEnter2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy")){
			Debug.Log("hit enemy");
			Destroy(other.transform.parent.gameObject);
			Application.LoadLevelAdditive("battle");
			//mainObject.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
