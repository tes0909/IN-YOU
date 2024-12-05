using UnityEngine;

[CreateAssetMenu(fileName = "BirdStats", menuName = "ScriptableObjects/BirdStats", order = 1)]
public class BirdStats : ScriptableObject
{
    public string birdName = "Bird";
    public float maxHealth = 100f; // 최대 체력
    public float currentHealth = 100f; // 현재 체력
    public float attackPower = 10f; // 공격력
    public float moveSpeed = 5f;
    public float aggroRange = 10f;
    public float attackRange = 2f;
}
