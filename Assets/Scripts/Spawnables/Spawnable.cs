using System.Collections;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public abstract class Spawnable : MonoBehaviour
{    
    public CharacterController characterController;

    internal GameObject PositionTarget;
    internal SpawnType spawnType;
    internal float spawnTime;
    internal float speed;

    internal bool isSpawned = false;
    internal bool isAtPosition = false;

    void Start()
    {
    }

    public void Awake()
    {
        StartCoroutine(Spawn());
    }

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
        print("done"); 
        yield return new WaitForSeconds(spawnTime);
        print("done1");
        isSpawned = true;
    }

    public void FollowPosition()
    {
        if (!isAtPosition)
        {
            Vector3 direction = (PositionTarget.transform.position - transform.position).normalized;
            characterController.Move(direction * speed * Time.deltaTime);
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
        if (other.gameObject == PositionTarget.gameObject)
        {
            isAtPosition = false;
        }
    }
}
