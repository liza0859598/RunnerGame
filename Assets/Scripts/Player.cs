using TMPro;
using UnityEngine;

public class Player : Damagable
{    
    public PlayerData playerData;
    public TextMeshProUGUI healthText;

    void Start()
    {
        health = playerData.health;
        damage = playerData.damage;
        healthText.text = "Health: " + health;
    }

    public override void Awake()
    {
        
    }

   void Update()
   {
        CheckHealth();
   }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        healthText.text = "Health: " + health;
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void OnTriggerExit(Collider other)
    {
    }
}
