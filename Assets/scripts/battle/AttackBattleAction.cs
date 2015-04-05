using UnityEngine;
using System.Collections;


public class AttackBattleAction : BattleAction{
	
	private BattleEntity attacker;
	private BattleEntity target;
	
	public AttackBattleAction(int _speed, BattleEntity _attacker, BattleEntity _target) 
		:base(_speed){
		this.attacker = _attacker;
		this.target = _target;
	}
	
	public override void doAction()
	{
		int damage = attacker.getCalculatedAtk() - target.getCalculatedDef();
		
		//Don't let damage go less than 0
		damage = (damage < 0) ? 0 : damage;
		
		target.setHp(target.getHp() - damage);
		//System.out.printf("%s attacks %s for %d damage. \n", attacker.getName(), target.getName(), damage);
	}
	
	
}
