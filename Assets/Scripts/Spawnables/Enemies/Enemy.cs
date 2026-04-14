using System.Collections;
using UnityEngine;

public abstract class Enemy : Damagable
{
    public new EnemyData data;
    public Bullet bullet;
    
    internal Animator animator;
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
        animator = GetComponentInChildren<Animator>();
        base.Awake();
        
    }

    public override void Update()
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
        animator.SetTrigger("Attack");
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
