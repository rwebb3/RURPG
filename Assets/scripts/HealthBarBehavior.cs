using UnityEngine;
using System.Collections;

public class HealthBarBehavior : MonoBehaviour {
	public float health;
	public float maxHealth;

	private float previousHealth;
	private float tempHealth;

	Vector3 startScale;
	// Use this for initialization
	void Start () {
		startScale = this.transform.localScale;
	}

	public void setHealth(float newHealth){
		this.previousHealth = this.health;
		this.health = newHealth;
	}
	// Update is called once per frame
	void Update () {
		tempHealth = Mathf.Lerp(previousHealth, health, Time.time);
		float healthPercent = tempHealth/maxHealth;
		this.transform.localScale = new Vector3(startScale.x * healthPercent, startScale.y, startScale.z);
	}
}
