using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public Rigidbody2D rb;
    public int damage;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            SoundManager.PlaySound("playerHit");
        }
        EnemyTwo enemyTwo = hitInfo.GetComponent<EnemyTwo>();
        if (enemyTwo != null)
        {
            enemyTwo.TakeDamage(damage);
            SoundManager.PlaySound("playerHit");
        }
        EnemyThree enemyThree = hitInfo.GetComponent<EnemyThree>();
        if (enemyThree != null)
        {
            enemyThree.TakeDamage(damage);
            SoundManager.PlaySound("playerHit");
        }

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SoundManager.PlaySound("playerHit");
    }
    
}
