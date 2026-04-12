using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using System.Collections;

public class TrackManager : MonoBehaviour
{
    public Spawnable[] resources;
    public TrackData trackData;
    public float distFront = 50.0f;
    public float distBack = -5.0f;

    internal float speed;

    private List<GameObject> lanes = new List<GameObject>();

    void Awake()
    {
        foreach (Transform lane in transform) {
            lanes.Add(lane.gameObject);
        }
        speed = trackData.speed;
    }

    void Start()
    {
        StartCoroutine(SpawnResource());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            spawn(resources[0]);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            spawn(resources[1], 1);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            spawn(resources[2], 2);
        }
    }

    public Spawnable spawn(Spawnable spawnable, int laneIndex = 0)
    {
        Spawnable instance = Instantiate(spawnable);

        float distance = distFront;
        GameObject PositionTarget = lanes[laneIndex].transform.GetChild(0).gameObject;

        if (instance.spawnType == SpawnType.back)
        {
            distance = distBack;
            PositionTarget = lanes[laneIndex].transform.GetChild(1).gameObject;
        }

        Vector3 spawnPosition = new Vector3(
            lanes[laneIndex].transform.position.x,
            lanes[laneIndex].transform.position.y,
            lanes[laneIndex].transform.position.z + distance
        );

        instance.transform.position = spawnPosition;
        instance.PositionTarget = PositionTarget;

        return instance;
    }

    IEnumerator SpawnResource()
    {
        yield return new WaitForSeconds(1.5f);
        int laneIndex = Random.Range(0, lanes.Count);
        int resourceIndex = Random.Range(0, resources.Length);

        spawn(resources[resourceIndex], laneIndex);
        StartCoroutine(SpawnResource());
    }
}
