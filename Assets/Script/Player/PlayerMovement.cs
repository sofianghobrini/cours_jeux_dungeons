using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    private Vector2 movement;

    public Rigidbody2D rb;

    public Animator animator;

    public SpriteRenderer spriteRenderer;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;


        animator.SetFloat("Speed", movement.sqrMagnitude);
        

        if(movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}
