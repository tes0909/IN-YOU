using UnityEngine;

[CreateAssetMenu(fileName = "ZombieStats", menuName = "ScriptableObjects/ZombieStats", order = 1)]
public class ZombieStats : ScriptableObject
{
    public string zombieName = "Zombie"; 
    public float maxHealth = 100f; // 최대 체력
    public float currentHealth = 100f; // 현재 체력
    public float attackPower = 10f; // 공격력
    public float moveSpeed = 2f; // 이동 속도
    public float aggroRange = 5f; // 추격 범위
    public float attackRange = 1f; // 공격 범위
}
