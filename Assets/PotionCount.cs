using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameData.current != null){
			this.transform.gameObject.GetComponent<Text>().text = GameData.current.healthPots.ToString();
		}
	}
}
