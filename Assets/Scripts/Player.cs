﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public DeathScreen deathScreen;
    private Vector2 spawnPosition;

	// Use this for initialization
	void Start () {
        spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fall()
    {
        Camera.main.GetComponent<CameraFollow2D>().target = null;
        GameObject.Instantiate(deathScreen);
    }

    public void respawn()
    {
        transform.position = spawnPosition;
        Camera.main.GetComponent<CameraFollow2D>().target = gameObject.transform;
    }
}
