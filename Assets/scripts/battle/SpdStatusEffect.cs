
public class SpdStatusEffect : StatusEffect{
	
	
	public SpdStatusEffect(BattleEntity _entity, int _buffValue,
	                       string _buffName) :base (_entity, _buffValue, _buffName){
	}

	public override void applyEffect() {
		this.entity.setCur_spd(this.entity.getBase_spd() + buffValue);
		
	}
	
}
