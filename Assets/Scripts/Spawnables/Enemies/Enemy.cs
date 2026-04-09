using System.Collections;
using UnityEngine;

public abstract class Enemy : Spawnable
{
    public EnemyData data;

    internal int health;
    internal int damage;

    void Start()
    {
        health = data.health;
        damage = data.damage;
        spawnType = data.spawnType;
        spawnTime = data.spawnTime;
        speed = data.speed;
    }

    void Update()
    {
        if (!isSpawned) {
            return;
        }
        FollowPosition();
    }
}
