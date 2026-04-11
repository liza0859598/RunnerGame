using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    public float dangerGainPerSecond = 1;
    public int startDangerBonus = 40;
    
    public List<bool> spawnInLane = new List<bool> {true, true, true};
}
