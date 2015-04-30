using UnityEngine;
using System.Collections;

public class RowdyEncounter : MonoBehaviour {
	public AudioClip laughSound;
	public AudioClip slashSound;
	public GameObject firstPanel;
	public GameObject panelToAppearOn;

	private bool encountered = false;
	private bool hasAppeared = false;


	public GameObject killPanel;
	public GameObject gameOverPanel;
	private float waitToKill = -1f;


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("here");
		if(other.tag.Equals("Player")){
			firstPanel.SetActive(true);
			encountered = true;
		}
	}
	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().enabled = false;
	}

	private bool dialogueComplete(){
		return this.encountered && this.panelToAppearOn.activeInHierarchy;
	}
	private void killPlayer(){
		waitToKill = .7f;
	}

	IEnumerator playerDeath(){
		Debug.Log("killingPlayer");
		this.GetComponent<AudioSource>().PlayOneShot(slashSound);
		killPanel.SetActive(true);
		float timeToShowKillPanel = .2f;
		while (timeToShowKillPanel > 0){
			timeToShowKillPanel -= Time.deltaTime;
			yield return null;
		}
		killPanel.SetActive(false);
		float waitToShowEnd = .3f;
		while (waitToShowEnd > 0){
			waitToShowEnd -= Time.deltaTime;
			yield return null;
		}
		StartCoroutine("gameOver");
	}

	IEnumerator gameOver(){
		this.gameOverPanel.SetActive(true);
		float waitTime = 5f;
		while (waitTime > 0f){
			waitTime -= Time.deltaTime;
			yield return null;
		}
		if (waitTime < 0f){
			Application.LoadLevel("MainMenu");
			yield return null;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//kill player
		if (waitToKill > 0){
			waitToKill -= Time.deltaTime;
			if (waitToKill <= 0){
				waitToKill = -1f;
				StartCoroutine("playerDeath");
			}
		}

		if (dialogueComplete() && !this.hasAppeared){
			this.GetComponent<SpriteRenderer>().enabled = true;
			this.GetComponent<AudioSource>().PlayOneShot(laughSound);
			this.hasAppeared = true;

		}
	}
}
