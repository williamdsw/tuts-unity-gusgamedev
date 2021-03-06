﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    // || Cached References

    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0.5f, 1f);
    }

    private void SpawnEnemies()
    {
        if (playerController)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
        }
    }
}
