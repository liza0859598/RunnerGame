using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using System.Collections;

public class TrackManager : MonoBehaviour
{
    public Spawnable[] resources;
    public Obstacle[] obstacles;
    public TrackData trackData;
    public float distFront = 50.0f;
    public float distBack = -5.0f;

    public GameObject winPanel;
    public GameObject losePanel;

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
        StartCoroutine(SpawnObstacle());
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

        float distance = distFront + spawnable.transform.position.z;
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
        int index = Random.Range(0, resources.Length);

        spawn(resources[index], laneIndex);
        StartCoroutine(SpawnResource());
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(1f);
        int laneIndex = Random.Range(0, lanes.Count);
        int index = Random.Range(0, obstacles.Length);

        spawn(obstacles[index], laneIndex);
        StartCoroutine(SpawnObstacle());
    }
}
