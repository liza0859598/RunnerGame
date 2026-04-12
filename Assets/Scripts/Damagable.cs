using UnityEngine;

public class Damagable : Spawnable
{
    internal int health;
    internal int damage;

    public void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
