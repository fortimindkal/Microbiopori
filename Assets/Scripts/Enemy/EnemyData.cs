using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHealth = 100;
    public int damage = 10;
    public float moveSpeed = 3f;
    public AudioClip deathSound;
}