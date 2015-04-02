using UnityEngine;
using System.Collections;

public abstract class BattleAction : MonoBehaviour{
	
	private int speed;
	
	public BattleAction(int _speed)
	{
		this.speed = _speed;
	}
	
	public abstract void doAction();
}
