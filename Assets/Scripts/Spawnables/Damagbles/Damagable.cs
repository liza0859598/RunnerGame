using UnityEngine;

public class Damagable : Spawnable
{
    internal int health;
    internal int damage;


    public virtual void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
    }
}
