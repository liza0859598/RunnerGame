using System;
using UnityEngine;

public class Obstacle : Spawnable
{
    public int damage = 1;
    public bool isUnstopable = false;

    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == PositionTarget)
        {
            Destroy(gameObject);
            return;
        }

        else if (!isUnstopable && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        Damagable damagable = other.gameObject.GetComponent<Damagable>();
        
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
