using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public bool isAlive = true;

    public Transform healthBarUI;
    public GameObject healthBarPrefab;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBarUI();
    }

    public void takeDamage(int damage)
    {

        if (isAlive)
        {
            currentHealth -= damage;
            UpdateHealthBarUI();
            
            if (currentHealth <= 0)
            {
                isAlive = false;
                animator.SetTrigger("Die");
            }
        }

    }

    public void UpdateHealthBarUI()
    {
        foreach(Transform child in healthBarUI)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(healthBarPrefab, healthBarUI);
        }
    }

    public void DisablePlayerVisual()
    {
        spriteRenderer.enabled = false;
    }
}
