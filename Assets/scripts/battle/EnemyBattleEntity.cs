using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemyBattleEntity : BattleEntity {

	private int AGGRESSIVE_STATE = 1;
	private int DEFENSIVE_STATE = 2;
	
	
	private int AIState;
	
	public EnemyBattleEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName, string sprite) 
		:base(hp, sp, atk, def, spd, maxHP, maxSP, entityName, sprite)
	{

	}
	
	public BattleAction getEnemyAction(List<PlayerBattleEntity> playerCharacters,
	                                   List<EnemyBattleEntity> enemies)
	{	
		AIState = AGGRESSIVE_STATE;
		
		if (AIState == AGGRESSIVE_STATE)
		{
			int targetIndex = (int) Random.Range(0, playerCharacters.Count);
			PlayerBattleEntity target = playerCharacters[targetIndex];

			return new AttackBattleAction(this.getCur_spd(), this, target);
		}
		
		
		
		return null;
		
		
		
	}
}
