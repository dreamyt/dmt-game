using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    public Vector3 currentDirection;
    public Vector3 trackDirection;
    public Quaternion initialRotation;
    public Vector3 initialScale;
    public Vector3 initialDirection;
    public float speed = 0.05f;
    public float damage = 2.0f;

    /*
     * speelMode
     * 0 - one spell fly direct      ) --->
     * 1 - 1st of three                 / --->
     * 2 - 2nd of three                { +---->
     * 3 - 3rd of three                 \ --->
     */
    public int spellMode;

    public bool canDetect;

    public bool facingRight;
    //public Transform overlapSphereCube;
    public float range = 25.0f;

    /* Calculate the angle to rotate */
    public float module;
    private float rotationAngle; // The angle to rotate.

    // Start is called before the first frame update
    
    private void Awake()
    {
        initialScale = transform.localScale;
        initialRotation = transform.localRotation;
    }
    void Start()
    {
        rotationAngle = 0.0f;
        initialDirection = new Vector3 (1.0f, 0.0f, 0.0f);
        
        currentDirection = initialDirection;
        trackDirection = new Vector3(0.0f, 0.0f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + currentDirection * speed;
        if (canDetect)
        {
            trackEnemy(detectEnemy());
        }
        else
        {
            normalFly();
        }
    }

    public void setDirection(Vector2 newDirection)
    {
        currentDirection = newDirection;
    }
    
    public void TurnToLeft()
    {   // Originally faces right, so just turn to left when spawning spell if needed.
        facingRight = false;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        setDirection(Vector2.left);
    }

    public void SpellFlip()
    {
        facingRight = !facingRight;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }
    
    public void trackEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            module = Mathf.Sqrt(
                (enemy.transform.position.x - transform.position.x) *
                (enemy.transform.position.x - transform.position.x) +
                (enemy.transform.position.y - transform.position.y) *
                (enemy.transform.position.y - transform.position.y));
            trackDirection = enemy.transform.position - transform.position;
            //Debug.Log(trackDirection);
            setDirection(trackDirection / module);

            if ((facingRight && trackDirection.x < 0) || (!facingRight && trackDirection.x > 0))
            {
                SpellFlip();
            }
            
            rotationAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;

            if (facingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, rotationAngle+180);
            }
        }
        else
        {
            // If no enemy is found, just fly as normal.
            setDirection(facingRight? Vector2.right : Vector2.left);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public GameObject detectEnemy()
    {

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range, layer.value);

        if (cols.Length>0)
        {
            return cols[0].gameObject;
        }

        return null;
    }

    public void normalFly()
    {
        setDirection(facingRight? Vector2.right : Vector2.left);
    }
    public void ResetSpellAttack()
    {
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
        setDirection(new Vector2());
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        Debug.Log(layer.value);
        if (1<<collision.gameObject.layer == layer.value)
        {
            Debug.Log(collision.gameObject.layer);
            Debug.Log(layer.value);
            ResetSpellAttack();
            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private void OnEnable()
    {
        setDirection(facingRight? Vector2.right : Vector2.left);
    }
    
    
}
