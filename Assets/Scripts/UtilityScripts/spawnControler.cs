﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnControler : MonoBehaviour
{

    //place the spawner object that uses this script at the x location that you desire to spawn the object at

    public GameObject objectToSpawn; // the prefab for which to spawn
    public float maxY = 2.0f; // value
    public float minY = -2.0f;
    public float spawnChance = 1f; //percent chance per second to spawn

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0f, 100.0f);
        if (random < (spawnChance) * Time.deltaTime)
        {
            Vector3 position = new Vector3(transform.position.x, Random.Range(minY, maxY), 0);
            Instantiate(objectToSpawn, position, Quaternion.identity);
        }
    }

}