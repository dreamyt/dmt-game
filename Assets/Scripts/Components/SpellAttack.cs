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

    public bool canDetect;
    //public Transform overlapSphereCube;
    public float range = 25.0f;

    /* Calculate the */
    public float module;
    public float angle;


    // Start is called before the first frame update
    void Start()
    {
        initialState = transform;
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

    public void trackEnemy(GameObject enemy)
    {
        module = Mathf.Sqrt((enemy.transform.position.x-transform.position.x) * (enemy.transform.position.x - transform.position.x)+ (enemy.transform.position.y - transform.position.y)*(enemy.transform.position.y - transform.position.y));
        trackDirection = enemy.transform.position - transform.position;
        setDirection(trackDirection / module);
    }

    public GameObject detectEnemy()
    {

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range, 1 << LayerMask.NameToLayer("Enemy"));
        //Collider[] cols = Physics.OverlapSphere(transform.position, 50f);
        //Collider[] cols = Physics.OverlapSphere(overlapSphereCube.position, range, 1 << LayerMask.NameToLayer("Enemy"));
        //if(cols!=null && cols.Length>0) Debug.Log(cols[0]);
        if (cols.Length > 0)
        {
            for(int i=0; i<cols.Length; i++)
            {
                Debug.Log(cols[i].gameObject.name);
            }
        }
        return cols[0].gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

}