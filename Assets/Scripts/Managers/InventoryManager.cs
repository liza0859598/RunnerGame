using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int ammoCount = 0;
    
    internal List<CollectableType> inventory = new List<CollectableType>(); 
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void craft(List<CollectableType> items)
    {
        if (items.Contains(CollectableType.Scraps) &&
            items.Contains(CollectableType.Powder))
        {
            ammoCount++;
        }

        items.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableType collectableType = other.gameObject.GetComponent<Collectable>().type;
        
        if (collectableType == CollectableType.Ammo)
        {
            ammoCount++;
            Destroy(other.gameObject);
        }
        else if (collectableType == CollectableType.Scraps || collectableType == CollectableType.Powder)
        {
            inventory.Add(CollectableType.Scraps);
        }
    }
}
