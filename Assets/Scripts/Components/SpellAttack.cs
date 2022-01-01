using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    Transform initialState;
    public Vector3 currentDirection;
    public Vector3 trackDirection;
    public Vector3 initialDirection;
    public float speed = 0.05f;

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

    /* Calculate the */
    public float module;
    private float rotationAngle; // The angle to rotate.

    // Start is called before the first frame update
    void Start()
    {
        initialState = transform;
        rotationAngle = 0.0f;
        initialDirection = new Vector3 (1.0f, 0.0f, 0.0f);
        trackDirection = new Vector3(0.0f, 0.0f, 0.0f);
        currentDirection = initialDirection;

        canDetect = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + currentDirection * speed;
        if (canDetect)
        {
            trackEnemy(detectEnemy());
        }
    }

    public void setDirection(Vector2 newDirection)
    {
        currentDirection = newDirection;
    }

    public void TurnToRight()
    {
        facingRight = true;
        transform.localScale = new Vector3(2,1,1);
    }
    public void TurnToLeft()
    {
        facingRight = false;
        transform.localScale = new Vector3(-2, 1, 1);
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
            
            rotationAngle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
            
            if (facingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0,0, rotationAngle+180);
            }
        }
        else
        {
            Debug.Log("Left or Right!");
            setDirection(facingRight? Vector2.right : Vector2.left);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public GameObject detectEnemy()
    {

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range, 1 << LayerMask.NameToLayer("Enemy"));

        if (cols.Length > 0)
        {
            for(int i=0; i<cols.Length; i++)
            {
                Debug.Log(cols[i].gameObject.name);
            }
        }

        if (cols.Length>0)
        {
            return cols[0].gameObject;
        }

        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

}
