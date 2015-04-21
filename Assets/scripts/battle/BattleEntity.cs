using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BattleEntity : MonoBehaviour {
	List<GameObject> playerActionButtons = new List<GameObject>();
	public GameObject playerGUI; //the usable abilities by this character
	//private UIPanel playerGUI; //the actual panel
	
	private int hp;
	private int sp;
	private int base_atk;
	private int cur_atk;
	private int base_def;
	private int cur_def;
	private int base_spd;
	private int cur_spd;
	private int maxHP;
	private int maxSP;
	private string entityName;

	private Timer timer;
	private List<StatusEffect> statusEffects;
	private string sprite;
	
	private bool myTurn = false;
	private bool canAttack = false;
	
	private GameObject[] enemies;
	private GameObject[] players;
	public GameObject battleManager;
	private Text alertMessageBox;
	private float waitForEnd = -1f;

	void Start(){
		alertMessageBox = GameObject.FindGameObjectWithTag("AlertText").GetComponent<Text>();
		//Debug.Log(alertMessageBox.text);
		if (this.transform.gameObject.tag.Equals("BattlePlayer")){
			setupListOfButtons();
		}
	}

	public void setupEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName, string sprite) 
	{
		this.hp = hp;
		this.sp = sp;
		this.base_atk = atk;
		this.cur_atk = atk;
		this.base_def = def;
		this.cur_def = def;
		this.base_spd = spd;
		this.cur_spd = spd;
		this.maxHP = maxHP;
		this.maxSP = maxSP;
		this.entityName = entityName;
		this.timer = new Timer(spd);
		this.statusEffects = new List<StatusEffect>();
		this.sprite = sprite;
	}
	
	public int getHp() {
		return hp;
	}
		
	public void setHp(int hp) {
		this.hp = hp;
	}
		
	public int getSp() {
		return sp;
	}
	
	public void setSp(int sp) {
		this.sp = sp;
	}
	
	public int getBase_atk() {
		return base_atk;
	}
	
	public void setBase_atk(int base_atk) {
		this.base_atk = base_atk;
	}
	
	public int getCur_atk() {
		return cur_atk;
	}
	
	public void setCur_atk(int cur_atk) {
		this.cur_atk = cur_atk;
	}
	
	public int getBase_def() {
		return base_def;
	}
	
	public void setBase_def(int base_def) {
		this.base_def = base_def;
	}
	
	public int getCur_def() {
		return cur_def;
	}
	
	public void setCur_def(int cur_def) {
		this.cur_def = cur_def;
	}
	
	public int getBase_spd() {
		return base_spd;
	}
	
	public void setBase_spd(int base_spd) {
		this.base_spd = base_spd;
	}
	
	public int getCur_spd() {
		return cur_spd;
	}
	
	public void setCur_spd(int cur_spd) {
		this.cur_spd = cur_spd;
	}
	
	public int getMaxHP() {
		return maxHP;
	}
	
	public void setMaxHP(int maxHP) {
		this.maxHP = maxHP;
	}
	
	public int getMaxSP() {
		return maxSP;
	}
	
	public void setMaxSP(int maxSP) {
		this.maxSP = maxSP;
	}
	
	public string getEntityName() {
		return entityName;
	}
	
	public void setEntityName(string entityName) {
		this.entityName = entityName;
	}
	
	/*public bool isMyTurn()
	{
		return this.timer.tick();
	}*/
	
	public void addStatusEffect(StatusEffect statusEffect)
	{
		this.statusEffects.Add(statusEffect);
	}
	
	public List<StatusEffect> getStatusEffects()
	{
		return this.statusEffects;
	}
	
	public int getCalculatedDef()
	{
		foreach(StatusEffect effect in statusEffects)
		{
			if (effect is DefStatusEffect)
			{
				effect.applyEffect();
			}
		}
		
		int calculatedDef = cur_def;
		
		cur_def = base_def;

		return calculatedDef;
	}
	
	public int getCalculatedAtk()
	{
		
		foreach (StatusEffect effect in statusEffects)
		{
			if (effect is AtkStatusEffect)
			{
				effect.applyEffect();
			}
		}
		
		int calculatedAtk = cur_atk;
		
		cur_atk = base_atk;

		return calculatedAtk;
	}
	
	public int getCalculatedSpd()
	{
		foreach (StatusEffect effect in statusEffects)
		{
			if (effect is SpdStatusEffect)
			{
				effect.applyEffect();
			}
		}
		
		int calculatedSpeed = cur_spd;
		cur_spd = base_spd;

		return calculatedSpeed;
	}
	
	public Sprite getSprite(){
		Sprite theSprite = Resources.Load<Sprite>(this.sprite);
		return theSprite;
	}
	
	public void setSprite(string newSprite){
		this.sprite = newSprite;
	}

	private void setupListOfButtons(){
		foreach(Transform child in playerGUI.transform){
			if (child.CompareTag("PlayerActionButton")){
				playerActionButtons.Add(child.gameObject);
			}
		}
	}

	void takeTurn(){
		//set things up
		if (this.alertMessageBox == null){
			this.alertMessageBox = GameObject.FindGameObjectWithTag("AlertText").GetComponent<Text>();
		}
		myTurn = true;
		canAttack = true;
		if (this.transform.gameObject.tag.Equals("BattlePlayer")){
			playerGUI.SetActive(true);
			playerGUI.GetComponent<RadioButtons>().ForceToValue("AttackButton");
		}
		enemies = GameObject.FindGameObjectsWithTag("BattleEnemy");
		players = GameObject.FindGameObjectsWithTag("BattlePlayer");
		alertMessageBox.text = this.entityName + "'s turn";
	}
	
	private void endTurn(){
		myTurn = false;
		canAttack = false;
		if(this.transform.gameObject.tag.Equals("BattlePlayer")){
			playerGUI.GetComponent<RadioButtons>().ForceToValue("AttackButton");
			playerGUI.SetActive(false);
			
		}
		battleManager.SendMessage("nextTurn");
	}
	
	private void endTurnAfterSeconds(float secondsToWait){
		this.waitForEnd = secondsToWait;
	}
	
	private void basicAttack(GameObject thingToAttack){
		if (this.transform.gameObject.tag.Equals("BattlePlayer")){
			playerGUI.SetActive(false);
		}	
			StartCoroutine("jerk");
			canAttack = false;
			this.alertMessageBox.text = this.entityName + " attacks " + thingToAttack.GetComponent<BattleEntity>().entityName + "!";
			endTurnAfterSeconds(1f);	
			thingToAttack.SendMessage("takeDamage", this.cur_atk);		
	}
	
	IEnumerator jerk(){
		Vector3 startLocation = this.transform.position;
		Vector3 targetLocation = new Vector3(startLocation.x, startLocation.y + 5, startLocation.z);
		while(Vector3.Distance(transform.position, targetLocation) > 0.05f)
		{
			transform.position = Vector3.Lerp (transform.position, targetLocation, Time.deltaTime * 15);
			yield return null;
		}
		while(Vector3.Distance(transform.position, startLocation) > 0.05f)
		{
			transform.position = Vector3.Lerp (transform.position, startLocation, Time.deltaTime * 15);
			yield return null;
		}
	}

	private void takeDamage(int attackDamage){
		this.hp = this.hp - attackDamage; //damage should be calculated some other way
	}
		
	
	void Update(){
		//update a timer if one is set
		if (waitForEnd > 0){
			waitForEnd -= Time.deltaTime;
			Debug.Log("waitForEnd: " + waitForEnd);
			if (waitForEnd <= 0){
				waitForEnd = -1f;
				endTurn();
			}
		}
	
		if (myTurn && canAttack){
		   if(this.transform.gameObject.tag.Equals("BattlePlayer")){
			if (playerGUI.GetComponent<RadioButtons>().currentValue.Equals("AttackButton")){
				foreach (GameObject anEnemy in enemies){
					if (anEnemy != null)
						anEnemy.SendMessage("hilite");
				}
				foreach (GameObject aPlayer in players){
					aPlayer.SendMessage("nohilite");
				}
				if (Input.GetMouseButtonDown(0)) {
					Vector2 clickPoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
					                                 Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
					RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);
					Debug.Log("mouse position: " + Input.mousePosition);
					if (hit.collider != null && hit.transform.tag.Equals("BattleEnemy")) {
						basicAttack(hit.transform.gameObject);
					}
				}
			}
			else if (playerGUI.GetComponent<RadioButtons>().currentValue.Equals("SkillButton")){
				foreach (GameObject anEnemy in enemies){
					if (anEnemy != null)
						anEnemy.SendMessage("nohilite");
				}
				foreach (GameObject aPlayer in players){
					aPlayer.SendMessage("hilite");
				}
			}
			else if (playerGUI.GetComponent<RadioButtons>().currentValue.Equals("DefendButton")){
					foreach (GameObject anEnemy in enemies){
						if (anEnemy != null)
							anEnemy.SendMessage("nohilite");
					}
					foreach (GameObject aPlayer in players){
						aPlayer.SendMessage("nohilite");
					}
					this.endTurn();
			}
			else{
				foreach (GameObject anEnemy in enemies){
					if (anEnemy != null)
						anEnemy.SendMessage("nohilite");
				}
				foreach (GameObject aPlayer in players){
					aPlayer.SendMessage("nohilite");
				}
			}
			
		   }
		   
		   else{
				//Debug.Log("enemy turn");
				endTurn();
				//battleManager.SendMessage("nextTurn");
		   }
		   
		}
	}
}
