using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameUIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            uiManager.Win();
        }
        else if (other.CompareTag("Obstacle"))
        {
            uiManager.Lose();
        }
    }
}