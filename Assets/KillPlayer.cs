using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	public GameObject Rowdy;

	public void killPlayer(){
		Debug.Log("player will die");
		Rowdy.SendMessage("killPlayer");
	}
}
