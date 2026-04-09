using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Scriptable Objects/Stage")]
public abstract class StageData : ScriptableObject
{
    public GameObject[] gameObjects;
}
