using UnityEngine;
using System.Collections;

public class HealthBarBehavior : MonoBehaviour {
	public float health;
	public float maxHealth;
	Vector3 startScale;
	// Use this for initialization
	void Start () {
		startScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float healthPercent = health/maxHealth;
		this.transform.localScale = new Vector3(startScale.x * healthPercent, startScale.y, startScale.z);
	}
}
