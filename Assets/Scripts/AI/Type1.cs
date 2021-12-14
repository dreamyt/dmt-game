using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1 : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public bool FacingRight = true;
    float face;
    public float speed = 3;

    [Header("Raycast offset settings")] 
    [SerializeField] private float offsetX=0;
    [SerializeField] private float offsetY=0;
    [SerializeField] private float dist = 1;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (FacingRight)
            face = transform.localScale.x;
        else
            face = -transform.localScale.x;
    }

    private void DebugLine(Vector3 pos, Vector3 dir, float dist, bool hit)
    {
        Color color = Color.white;
        if (hit)
        {
            color = Color.red;
        }
        Debug.DrawLine(pos, pos + (dir.normalized * dist), color);
    }

    private void Update()
    {
        bool forward_down = Physics2D.Raycast(new Vector2(transform.position.x+offsetX, transform.position.y+offsetY), new Vector2(face, -1), 1.3f*dist, LayerMask.GetMask("Tilemap_Platform"));
        bool forward = Physics2D.Raycast(new Vector2(transform.position.x+offsetX, transform.position.y+offsetY), new Vector2(face, 0), 1.2f*dist, LayerMask.GetMask("Tilemap_Platform"));
        bool down = Physics2D.Raycast(new Vector2(transform.position.x+offsetX, transform.position.y+offsetY), new Vector2(0, -1), 1f*dist, LayerMask.GetMask("Tilemap_Platform"));
        DebugLine(new Vector2(transform.position.x+offsetX, transform.position.y+offsetY), new Vector2(face, -1), 1.3f*dist, forward_down);
        DebugLine(new Vector2(transform.position.x+offsetX, transform.position.y+offsetY), new Vector2(face, 0), 1.2f*dist, forward);
        DebugLine(new Vector2(transform.position.x+offsetX, transform.position.y+offsetY), new Vector2(0, -1), 1f*dist, down);

        bool flip = false;

        if (down)
        {
            if (forward)
            {
                flip = true;
            }
            else if (!forward_down)
            {
                flip = true;
            }
        }
        if (flip)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            face = transform.localScale.x;
        }

        rigid.velocity = new Vector2(face * speed, rigid.velocity.y);
    }
}
