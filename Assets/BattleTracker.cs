using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleTracker : MonoBehaviour {
	public GameObject DamageIndicator;
	public GameObject HealthBar;

	public void takeDamage(int damageAmount) {
		DamageIndicator.SetActive(true);
		DamageIndicator.SendMessage("showDamage", damageAmount); //GetComponent<Text>().text = damageAmount.ToString();
		HealthBar.GetComponent<HealthBarBehavior>().updateHealth(damageAmount);
	}

}
