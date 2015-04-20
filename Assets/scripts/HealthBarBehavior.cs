using UnityEngine;
using System.Collections;

public class HealthBarBehavior : MonoBehaviour {
	private float health;
	private float maxHealth;

	private float previousHealth;
	private float tempHealth;

	Vector3 startScale;
	// Use this for initialization
	void Start () {
		startScale = this.transform.localScale;
		health = this.GetComponentInParent<BattleEntity>().getHp();
		previousHealth = 1; //this prevents the health bar from destorying it self right at the start (see Update())

	}

	public void updateHealth(float changeInHealth){
		float newHealth = this.health - changeInHealth;
		this.previousHealth = this.health;
		this.health = newHealth;
	}
	// Update is called once per frame
	void Update () {
		tempHealth = Mathf.Lerp(previousHealth, health, Time.time);
		if (tempHealth < 0)
			tempHealth = 0;
		float healthPercent = tempHealth/maxHealth;
		this.transform.localScale = new Vector3(startScale.x * healthPercent, startScale.y, startScale.z);
		if (tempHealth == 0)
			GameObject.Destroy(this.gameObject.GetComponentInParent<Transform>());
	}
}
