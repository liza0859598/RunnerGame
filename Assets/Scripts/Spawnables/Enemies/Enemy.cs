using System.Collections;
using UnityEngine;

public abstract class Enemy : Spawnable
{
    public EnemyData data;

    internal int health;
    internal int damage;
    internal int cost;

    void Start()
    {
        health = data.health;
        damage = data.damage;
        cost = data.cost;
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
