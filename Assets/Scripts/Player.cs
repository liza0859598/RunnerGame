using UnityEngine;

public class Player : Damagable
{    
    public PlayerData playerData;

    void Start()
    {
        health = playerData.health;
        damage = playerData.damage;
    }

   void Update()
   {
        CheckHealth();
   }

    public new void OnTriggerEnter(Collider other)
    {
    }

    public new void OnTriggerExit(Collider other)
    {
    }
}
