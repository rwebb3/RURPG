using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BattleEntity : MonoBehaviour {
	
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
	
}
