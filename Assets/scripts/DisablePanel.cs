﻿using UnityEngine;
using System.Collections;

public class DisablePanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NGUITools.SetActive(this.gameObject, false);
	}

	void Update () {

	}
}
