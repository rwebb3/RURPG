using UnityEngine;
using System.Collections;

public class HealthBarBehavior : MonoBehaviour {
	private float previousHealth;
	private float tempHealth;
	private float healthPercent;
	private float health;

	private bool enabled = false;
	private bool healthSet = false;

	Vector3 startScale;
	// Use this for initialization
	void Start() {
		this.startScale = this.transform.localScale;
		this.health = this.GetComponentInParent<BattleEntity>().getHp(); //this prevents the health bar from destorying it self right at the start (see Update())
		this.previousHealth = this.health;
	}

	public void updateHealth(int changeInHealth){
		healthSet = true;
		this.previousHealth = this.health;
		this.health = this.health - changeInHealth;
	}
	
	// Update is called once per frame
	void Update () {
			this.tempHealth = Mathf.Lerp(this.previousHealth, this.health, Time.time);
			this.healthPercent = tempHealth/this.GetComponentInParent<BattleEntity>().getMaxHP();
			this.transform.localScale = new Vector3(this.startScale.x * this.healthPercent, this.startScale.y, this.startScale.z);
			if (this.tempHealth <= 0){ //if tempHealth started at 0 it would destory itself immediately
				//Debug.Log("current HP: " + this.GetComponentInParent<BattleEntity>().getHp());
				this.transform.GetComponentInParent<BattleEntity>().die();
			}
		}
}
