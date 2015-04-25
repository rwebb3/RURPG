using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EntityStats{
	public int hp;
	public int sp;
	public int base_atk;
	public int cur_atk;
	public int base_def;
	public int cur_def;
	public int base_spd;
	public int cur_spd;
	public int maxHP;
	public int maxSP;
	public string entityName;

	//private Timer timer;
	public List<StatusEffect> statusEffects;
	public string sprite;

	public EntityStats(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName, string sprite) 
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
		//this.timer = new Timer(spd);
		this.statusEffects = new List<StatusEffect>();
		this.sprite = sprite;
	}
}

