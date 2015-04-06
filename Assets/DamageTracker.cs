using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageTracker : MonoBehaviour {
	public GameObject DamageIndicator;
	public GameObject HealthBar;
	public float damageToTake;

	private float timeToShow;
	private float timer;
	private float growAmount;

	private Vector3 startScale;
	private float currentXScale;
	private float currentYScale;

	// Use this for initialization
	void Start(){
		TakeDamage(damageToTake);
	}

	void TakeDamage(float damageAmount) {
		startScale = DamageIndicator.transform.localScale;
		DamageIndicator.SetActive(true);

		timeToShow = 1.0f;
		timer = 0.0f;
		growAmount = 0.002f;

		if (damageAmount < 0f){
			DamageIndicator.GetComponent<Text>().color = Color.green;
		}
		else{
			DamageIndicator.GetComponent<Text>().color = Color.red;
		}

		DamageIndicator.GetComponent<Text>().text = damageAmount.ToString();
		HealthBar.GetComponent<HealthBarBehavior>().setHealth(HealthBar.GetComponent<HealthBarBehavior>().health - damageAmount);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeToShow){
			DamageIndicator.SetActive(false);
		}
		else{
			currentXScale = DamageIndicator.transform.localScale.x;
			currentYScale = DamageIndicator.transform.localScale.y;
			DamageIndicator.transform.localScale = new Vector3(currentXScale + growAmount, currentYScale + growAmount, DamageIndicator.transform.localScale.z);
		}
		
	}
}
