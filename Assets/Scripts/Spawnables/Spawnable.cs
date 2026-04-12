using System.Collections;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public abstract class Spawnable : MonoBehaviour
{    
    internal GameObject PositionTarget;
    internal SpawnType spawnType;
    internal float spawnTime;
    internal float speed;

    internal bool isSpawned = false;
    internal bool isAtPosition = false;


    void Update()
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PositionTarget.gameObject)
        {
            isAtPosition = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PositionTarget)
        {
            isAtPosition = false;
        }
    }
}
