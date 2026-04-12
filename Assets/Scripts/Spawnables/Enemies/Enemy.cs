using System.Collections;
using UnityEngine;

public abstract class Enemy : Damagable
{
    public new EnemyData data;
    public Bullet bullet;

    internal int cost;

    private bool isShooting = false;

    void Start()
    {
        
    }

    public override void Awake()
    {
        health = data.health;
        damage = data.damage;
        cost = data.cost;
        base.Awake();
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

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
