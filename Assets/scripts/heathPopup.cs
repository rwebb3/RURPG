using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class heathPopup : MonoBehaviour {
	private float timeToShow;
	private float timer;
	private float growAmount;
	
	private Vector3 startScale;
	private float currentXScale;
	private float currentYScale;

	// Use this for initialization
	private void showDamage(int damageAmount) {
		startScale = this.gameObject.transform.localScale;
		this.gameObject.SetActive(true);
		
		timeToShow = 0.5f;
		timer = 0.0f;
		growAmount = 0.002f;
		
		if (damageAmount < 0f){
			this.gameObject.GetComponent<Text>().color = Color.green;
			damageAmount = damageAmount * -1;
		}
		else{
			this.gameObject.GetComponent<Text>().color = Color.red;
		}
		this.gameObject.GetComponent<Text>().text = damageAmount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeToShow){
			this.gameObject.transform.localScale = startScale;
			this.gameObject.SetActive(false);
		}
		else{
			currentXScale = this.gameObject.transform.localScale.x;
			currentYScale = this.gameObject.transform.localScale.y;
			this.gameObject.transform.localScale = new Vector3(currentXScale + growAmount, currentYScale + growAmount, this.gameObject.transform.localScale.z);
		}
	}
}
