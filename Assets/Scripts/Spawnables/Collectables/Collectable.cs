using UnityEngine;

public class Collectable : Spawnable
{
    public CollectableData data;

    internal CollectableType type;

    void Start()
    {
        type = data.type;
        spawnType = data.spawnType;
        spawnTime = data.spawnTime;
        speed = data.speed;
        StartCoroutine(Spawn());
    }

    private new void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PositionTarget)
        {
            Destroy(gameObject);
        }
    }
}
