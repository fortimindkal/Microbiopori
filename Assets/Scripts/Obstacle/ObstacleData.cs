using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle Data", menuName = "Obstacle Data")]
public class ObstacleData : ScriptableObject
{
    public string obstacleName;     // Name of the obstacle.
    public int healthImpact;        // Health impact on the player.
}