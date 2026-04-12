using UnityEngine;

public class Collectable : Spawnable
{
    public new CollectableData data;

    internal CollectableType type;

    public override void Awake()
    {
        type = data.type;
        base.Awake();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject == PositionTarget)
        {
            Destroy(gameObject);
        }
    }
}
