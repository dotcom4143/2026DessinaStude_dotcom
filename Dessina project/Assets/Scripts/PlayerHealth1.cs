using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHp;

    public bool IsDead = false;

    void Start()
    {
        currentHp = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if(IsDead) return;

        currentHp -= damage;

        if(currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }

        Debug.Log("Player HP: " + currentHp);
    }

    void Die()
    {
        IsDead = true;
        Debug.Log("Game Over.");
    }

}