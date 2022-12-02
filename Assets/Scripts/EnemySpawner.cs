using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyGO; // Enemy Prefabs
    public float maxSpawnRateInSecond = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy",maxSpawnRateInSecond);
        InvokeRepeating("IncreaseSpawnRate",0f, 30f); // augumenter le taux d'apparution d'enemy chaque 30sec
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Fonction de créer un Enemy
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // C'est la limite de l'écran en bas à gauche
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // C'est la limite de l'écran en haut à droite

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, min.y), max.y);
        
        ScheduleNextEnemySpawn(); //fonction qui fait apparaître et teleporter les Enemy

        }
    
    // definir la fonction de teleport
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;
        if (maxSpawnRateInSecond > 4f)
        {
            spawnInNSeconds = Random.Range(4f, maxSpawnRateInSecond);
        }
        else
        {
            spawnInNSeconds = 4f;
        }
        
        Invoke("SpawnEnemy",spawnInNSeconds);

    }
    
    // definir la fonction qui augment le niveau des enemy
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSecond > 4f)
        {
            maxSpawnRateInSecond--;
        }

        if (maxSpawnRateInSecond == 4f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
        
    }
    

}
