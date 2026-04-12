using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int ammoCount = 0;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI resourceText;

    public Bullet bullet;

    internal List<CollectableType> inventory = new List<CollectableType>(); 
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammoCount > 0)
        {
            Instantiate(bullet, transform.position + bullet.transform.position, transform.rotation);
            addAmmo(-1);
        }
    }

    void Craft(List<CollectableType> items)
    {
        if (items.Contains(CollectableType.Scrap) &&
            items.Contains(CollectableType.Powder))
        {
            addAmmo();
        }
        resourceText.text = "Resources:";
        items.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable = other.gameObject.GetComponent<Collectable>();
        if (collectable != null){

            CollectableType collectableType = other.gameObject.GetComponent<Collectable>().type;

            if (collectableType == CollectableType.Ammo)
            {
                addAmmo();
                Destroy(other.gameObject);
            }
            else if (collectableType == CollectableType.Scrap || collectableType == CollectableType.Powder)
            {
                addResource(collectableType);
                
                if (inventory.Count > 1)
                {
                    Craft(inventory);                
                }
                Destroy(other.gameObject);
            }
        }        
    }

    private void addAmmo(int amount = 1)
    {
        ammoCount += amount;
        ammoText.text = "Ammo: " + ammoCount;
    }

    private void addResource(CollectableType collectable)
    {
        inventory.Add(collectable);
        resourceText.text += " " + collectable;
    }


}
