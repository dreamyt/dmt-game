using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* This is the base class of Projectile */
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float acceleration = 0f;
    [SerializeField] private float damage = 1.0f;

    [SerializeField] private float lifeTime = 3f;

    // Returns the direction of this projectile    
    public Vector2 Direction;
    public Vector2 defaultDirection = new Vector2(1f, 0f);

    // Returns if the projectile is facing right   
    public bool FacingRight { get; set; }

    // Returns the speed of the projectile    
    public float Speed { get; set; }

    public float aimAngle { get; set; }
    static public float Damage;     // The damage of projectile

    // Internal
    private Rigidbody2D myRigidbody2D;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    public bool isAdvanced;


    private void Start()
    {
        //Direction = defaultDirection;
    }


    private void Awake()
    {
        Speed = speed;
        FacingRight = true;
        Damage = damage;
        Direction = new Vector2(1.0f, 0.0f);


        myRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    // Moves this projectile  
    public void MoveProjectile()
    {
        movement = Direction * (Speed / 10f) * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(myRigidbody2D.position + movement);

        Speed += acceleration * Time.deltaTime;

    }

    // Flips this projectile   
    public void FlipProjectile()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }

    // Set the direction and rotation in order to move
    public void SetDirection(Vector2 newDirection, bool isFacingRight = true)
    {
        Direction = newDirection;

        if (FacingRight != isFacingRight)
        {
            FlipProjectile();
        }

        // transform.rotation = rotation;

    }
    public void SetDirection(Vector2 newDirection, Quaternion rotation, bool isFacingRight = true)
    {
        Direction = newDirection;

        if (FacingRight != isFacingRight)
        {
            FlipProjectile();
        }

        // transform.rotation = rotation;

    }
    

    /* Part 5 - Return to pool */
    public void ResetProjectile()
    {
        spriteRenderer.flipX = false;
    }

    public void DisableProjectile()
    {
        spriteRenderer.enabled = false;  // If we don't disable the spriteRenderer, the bullet will fall down before disappear
        collider2D.enabled = false;
    }

    public void EnableProjectile()
    {

        spriteRenderer.enabled = true;
        collider2D.enabled = true;
    }
    
    
}

