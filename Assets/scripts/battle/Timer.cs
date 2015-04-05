using UnityEngine;
using System.Collections;

[System.Serializable]
public class Timer {
	
	private int value;
	private int speed;
	
	public Timer(int speed)
	{
		this.speed = speed;
		value = 100;
	}
	
	public bool tick()
	{
		value -= speed;
		int valueHolder = value;
		
		value = (value <= 0) ? 100 : value;
		
		return valueHolder <= 0;
	}
	
}
