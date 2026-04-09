using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public GameObject[] lanes;
    public CharacterController characterController;

    public float laneChangeSpeed = 10f;

    private int currentLane;
    private bool isSwitchingLanes = false;

    void Start()
    {
        currentLane = lanes.Length / 2;
        transform.position = lanes[currentLane].transform.position;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0)
            {
                currentLane--;
                isSwitchingLanes = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < lanes.Length - 1)
            {
                currentLane++;
                isSwitchingLanes = true;
            }
        }

        if (isSwitchingLanes)
        {
            float directionX = Mathf.Sign(lanes[currentLane].transform.position.x - transform.position.x);
            characterController.Move(new Vector3(directionX, 0, 0) * laneChangeSpeed *  Time.deltaTime);
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == lanes[currentLane])
        {
            isSwitchingLanes = false;
            characterController.Move(Vector3.zero);
            transform.position = new Vector3(lanes[currentLane].transform.position.x, transform.position.y, lanes[currentLane].transform.position.z);
        }
    }
}
