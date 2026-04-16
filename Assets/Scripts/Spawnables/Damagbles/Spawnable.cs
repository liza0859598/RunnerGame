using System.Collections;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class Spawnable : MonoBehaviour
{
    public SpawnableData data;

    public GameObject PositionTarget;
    internal SpawnType spawnType;
    internal float spawnTime;
    internal float speed;

    internal bool isSpawned = false;
    internal bool isAtPosition = false;


    public virtual void Awake()
    {
        spawnType = data.spawnType;
        spawnTime = data.spawnTime;
        speed = data.speed;
        StartCoroutine(Spawn());
    }

    public virtual void Update()
    {
        if (!isSpawned)
        {
            return;
        }
        FollowPosition();
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        isSpawned = true;
    }

    public void FollowPosition()
    {
        if (!isAtPosition)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                PositionTarget.transform.position,
                speed * Time.deltaTime
            );
            return;
        }
        else
        {
            transform.position = new Vector3(PositionTarget.transform.position.x, transform.position.y, PositionTarget.transform.position.z);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PositionTarget)
        {
            isAtPosition = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PositionTarget)
        {
            isAtPosition = false;
        }
    }
}
