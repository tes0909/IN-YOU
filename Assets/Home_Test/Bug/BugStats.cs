using UnityEngine;

[CreateAssetMenu(fileName = "BugStats", menuName = "ScriptableObjects/BugStats", order = 1)]
public class BugStats : ScriptableObject
{
    public string bugName = "Bug";
    public float maxHealth = 100f;
    public float currentHealth = 100f; 
    public float attackPower = 10f; 
    public float moveSpeed = 3f;
    public float aggroRange = 5f;
    public float attackRange = 1.5f;
}
