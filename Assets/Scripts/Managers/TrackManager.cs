using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class TrackManager : MonoBehaviour
{
    public Spawnable[] spawnables;
    public TrackData trackData;
    public float distFront = 50.0f;
    public float distBack = -5.0f;

    internal float speed;

    private List<GameObject> lanes = new List<GameObject>();

    void Start()
    {
        foreach (Transform lane in transform) {
            lanes.Add(lane.gameObject);
        }
        speed = trackData.speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            spawn(spawnables[0]);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            spawn(spawnables[1]);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            spawn(spawnables[2]);
        }
    }

    void spawn(Spawnable spawnable, int laneIndex = 0) 
    {
        float distance = distFront;
        GameObject PositionTarget = lanes[laneIndex].transform.GetChild(0).gameObject;
        if (spawnable.spawnType == SpawnType.back) {
            distance = distBack;
            PositionTarget = lanes[laneIndex].transform.GetChild(1).gameObject;
        }

        Vector3 spawnPosition = new Vector3(lanes[laneIndex].transform.position.x, lanes[laneIndex].transform.position.y, lanes[laneIndex].transform.position.z + distance);
        Spawnable instance = Instantiate(spawnable, spawnPosition, new Quaternion());
        instance.PositionTarget = PositionTarget;
    }
}
