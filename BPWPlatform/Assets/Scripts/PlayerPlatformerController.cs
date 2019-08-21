using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;


    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Test hurting/health
    public static int health;
    public int maxHealth = 3;
    public float invincibleTimer;




    Rigidbody2D rb;

    Collider2D myCollider;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        myCollider = this.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;





    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");



        if (Input.GetButtonDown("Jump") && grounded)
        {
            SoundManager.PlaySound("jumpSounds");
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
 
            }
        }




        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);


        targetVelocity = move * maxSpeed;



    }



    //TUTORIAL V1
    public void Hurt()
    {

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        health--;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            TriggerHurt(invincibleTimer);
            SoundManager.PlaySound("playerHurt");
        }
    }

    void Die()
    {
        //Restart Scene
        Application.LoadLevel(Application.loadedLevel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Hurt();
        }

        EnemyTwo enemyTwo = collision.collider.GetComponent<EnemyTwo>();
        if (enemyTwo != null)
        {
            Hurt();
        }

        EnemyThree enemyThree = collision.collider.GetComponent<EnemyThree>();
        if (enemyThree != null)
        {
            Hurt();

        }
        EnemyWater enemyWater = collision.collider.GetComponent<EnemyWater>();
        if (enemyWater != null)
        {
            Die();

        }

    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyProjectile enemyProjectile = hitInfo.GetComponent<EnemyProjectile>();
        if (enemyProjectile != null)
        {
            Hurt();
        }
    }


    /*Had erg veel moeite met de Projectile damage, dit zijn andere dingen die ik  heb geprobeerd. 
    Ben naar mijn Bullet script gegaan en daar heb ik de OnTriggerEnter manier gevonden. 
       
        EnemyProjectile enemyProjectile = collision.collider.GetComponent<EnemyProjectile>();
         if (enemyProjectile != null)
         {
             Hurt();

         }
     }

     /*private void OnCollisionEnter2D(Collision collision)
     {
         if (collision.gameObject.tag == "EnemyProjectile")
         {
             Hurt();
         }
     }*/


        public void TriggerHurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        //Ignore collision with enemy
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);
        Collider2D collider = myCollider;
        {
            myCollider.enabled = false;
            myCollider.enabled = true;
        }

        //Start Looping hurt
        animator.SetLayerWeight(1, 1);

        //Wait for invincibilty to end
        yield return new WaitForSeconds(hurtTime);

        //Stop blinking - Re-enable collision
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        animator.SetLayerWeight(1, 0);
    }


}