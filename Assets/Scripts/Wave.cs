using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public WaveData data = new WaveData();

    internal float dangerGainPerSecond;
    internal int startDangerBonus;

    internal List<bool> spawnInLane;

    void Start()
    {
        dangerGainPerSecond = data.dangerGainPerSecond;
        startDangerBonus = data.startDangerBonus;
        spawnInLane = data.spawnInLane;
    }

    void Update()
    {
        
    }
}
