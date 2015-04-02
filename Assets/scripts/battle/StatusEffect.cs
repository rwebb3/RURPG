
public abstract class StatusEffect {
	
	protected BattleEntity entity;
	protected int buffValue;
	protected string buffName;
	
	public StatusEffect(BattleEntity _entity, int _buffValue, string _buffName)
	{
		this.entity = _entity;
		this.buffValue = _buffValue;
		this.buffName = _buffName;
	}
	
	public abstract void applyEffect();
	
	
	
}
