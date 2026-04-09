using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -7);
    public float smoothSpeed = 5f;


    void LateUpdate()
    {        
        Vector3 target = player.position + offset;
        Vector3 currentDirection = (target - transform.position).normalized;
        //if (Mathf.Approximately(target.x, transform.position.x))
        //{
        //    transform.position = target;
        //}
        transform.position = Vector3.Lerp(transform.position, target, smoothSpeed * Time.deltaTime);

    }
}