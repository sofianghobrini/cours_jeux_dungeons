using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float attackRange = 1.5f; // The range of the player's attack


    public int damage = 10; // The amount of damage the player's attack does

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public PlayerHealth playerHealth;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerHealth.isAlive)
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        animator.SetTrigger("Attack");
        
        Vector2 attackDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Ennemy"))
            {
               Vector2 directionToEnemy = (collider.transform.position - transform.position).normalized;


                if(Vector2.Dot(attackDirection, directionToEnemy) > 0)
                {
                    EnemyAI enemyAI = collider.GetComponent<EnemyAI>();
                    if (enemyAI != null)
                    {
                        enemyAI.TakeDamage(damage);
                        Vector2 knockbackDirection = (collider.transform.position - transform.position).normalized;
                        enemyAI.rb.AddForce(knockbackDirection * 5f, ForceMode2D.Impulse); // Apply knockback force
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    
}
