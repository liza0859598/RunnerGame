using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class WaveManager : MonoBehaviour
{
    public List<WaveData> waves;
    public List<Spawnable> enemies;

    public TrackManager trackManager;

    private int currentWave = 0;
    private float dangerPoints = 0;

    private List<GameObject> aliveEnemies = new List<GameObject>();

    void Start()
    {
        StartWave();
    }

    void Update()
    {
        if (currentWave < waves.Count)
        {
            GainDanger();
            CheckWaveEnd();
        } 
    }

    void GainDanger()
    {
        dangerPoints += waves[currentWave].dangerGainPerSecond * Time.deltaTime;
    }

    void TrySpawnEnemy()
    {
        int maxCost = int.MinValue;
        Enemy enemy = null;

        foreach (Enemy en in enemies)
        {
            if (en.cost > maxCost)
            {
                maxCost = en.cost;
                enemy = en;
            }
        }

        if (dangerPoints >= enemy.cost)
        {
            for (int i = 0; i < waves[currentWave].spawnInLane.Count; i++)
            {
                if (waves[currentWave].spawnInLane[i])
                {
                    Spawn(enemy, i);
                }
            }
        }
    }
    

    void Spawn(Enemy enemy, int laneIndex)
    {
        aliveEnemies.Add(trackManager.spawn(enemy, laneIndex).gameObject);
    }

    void CheckWaveEnd()
    {
        aliveEnemies.RemoveAll(e => e == null);

        if (aliveEnemies.Count == 0)
        {
            NextWave();
        }
    }

    void StartWave()
    {
        dangerPoints += waves[currentWave].startDangerBonus;
        TrySpawnEnemy();
    }

    void NextWave()
    {
        currentWave++;

        if (currentWave >= waves.Count)
        {
            Debug.Log("All waves completed!");
            return;
        }

        StartWave();
    }
}