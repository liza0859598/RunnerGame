using UnityEngine;

[CreateAssetMenu(fileName = "EnemyShooter", menuName = "Scriptable Objects/EnemyShooter")]
public class EnemyData : SpawnableData
{
    public int health = 3;
    public int damage = 1;
    public int cost = 50;
}
