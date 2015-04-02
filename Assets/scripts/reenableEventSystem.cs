using UnityEngine;
using System.Collections;

public class reenableEventSystem : MonoBehaviour {
	public GameObject eventSystem;
	void OnEnable(){
		Debug.Log("yeah man");
		eventSystem.SetActive(true);
	}
}
