using System.Collections;
using UnityEngine;

public abstract class Enemy : Damagable
{
    public EnemyData data;
    public Bullet bullet;

    internal int cost;

    private bool isShooting = false;

    void Start()
    {
        
    }

    private void Awake()
    {
        health = data.health;
        damage = data.damage;
        cost = data.cost;
        spawnType = data.spawnType;
        spawnTime = data.spawnTime;
        speed = data.speed;
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (!isSpawned) {
            return;
        }
        FollowPosition();
        CheckHealth();

        if (isAtPosition && !isShooting)
        {
            StartCoroutine(Shoot());
            isShooting = true;
        }
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.15f);
        Instantiate(bullet, transform.position + bullet.transform.position, transform.rotation);
        isShooting = false;
        yield break;
    }
}
