
public class AtkStatusEffect : StatusEffect
{
	
	
	public AtkStatusEffect(BattleEntity _entity, int _buffValue,
	                       string _buffName) :base(_entity, _buffValue, _buffName){
	}

	public override void applyEffect() {
		this.entity.setCur_atk(this.entity.getBase_atk() + buffValue);
		
	}
	
}
