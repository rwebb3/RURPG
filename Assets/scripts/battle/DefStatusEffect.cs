using UnityEngine;
using System.Collections;


public class DefStatusEffect : StatusEffect {
	
	
	public DefStatusEffect(BattleEntity _entity, int _buffValue,
	                       string _buffName) :base(_entity, _buffValue, _buffName){
	}

	public override void applyEffect() {
		this.entity.setCur_def(this.entity.getBase_def() + buffValue);
		
	}
	
}
