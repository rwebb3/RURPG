using UnityEngine;
using System.Collections;


public class DefendBattleAction : BattleAction
{
	private BattleEntity defender;
	
	public DefendBattleAction(int _speed, BattleEntity _defender) :base(_speed){
		this.defender = _defender;
	}
	
	public override void doAction() {
		
		defender.addStatusEffect(new DefStatusEffect(defender, defender.getBase_def(), "Player Defend"));
		
	}
	
}
