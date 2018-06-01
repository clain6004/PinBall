﻿using System.Collections;
using UnityEngine;

public class StarController : MonoBehaviour {

    private float rotSpeed = 1.0f;

	// Use this for initialization
	void Start () {

        this.transform.Rotate(0, Random.Range(0, 360), 0);

	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(0, this.rotSpeed, 0);

	}
}
