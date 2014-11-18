//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
// edited by Robert Webb 11/17/2014
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Plays the specified sound.
/// </summary>

public class buttonSound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
	}
	
	public AudioClip audioClip;
	public Trigger trigger = Trigger.OnClick;
	public float pitch = 1f;
	
	void OnHover (bool isOver)
	{
		if (enabled && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
		{
			NGUITools.PlaySound(audioClip, GlobalVars.soundVolume, pitch);
		}
	}
	
	void OnPress (bool isPressed)
	{
		if (enabled && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
		{
			NGUITools.PlaySound(audioClip, GlobalVars.soundVolume, pitch);
		}
	}
	
	void OnClick ()
	{
		if (enabled && trigger == Trigger.OnClick)
		{
			NGUITools.PlaySound(audioClip, GlobalVars.soundVolume, pitch);
		}
	}
}