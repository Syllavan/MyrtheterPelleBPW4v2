using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;



    void Update()
    {

    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }


    }

    void Die()
    {
        Destroy(gameObject);
    }
}
