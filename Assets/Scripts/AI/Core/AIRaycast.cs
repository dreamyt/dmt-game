using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AIRaycast : MonoBehaviour
{
    private Rigidbody2D rigid;
    private CharacterFlip flip;
    private float face;
    public bool forward_down;
    public bool forward;
    [Header("Raycast offset settings")] 
    [SerializeField] private float offsetX=0;
    [SerializeField] private float offsetY=0;
    [SerializeField] private float angle = 0;
    [SerializeField] private float dist = 1;
    
    void Start()
    {
        flip = GetComponent<CharacterFlip>();
        rigid = GetComponent<Rigidbody2D>();
        if (flip.FacingRight)
        {
            face = transform.localScale.x;
        }
        else
        {
            face = -transform.localScale.x;
        }
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
       
        forward_down = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, math.abs(face)*math.tan(angle*math.PI/180)), 1.3f*dist, LayerMask.GetMask("Tilemap_Platform"));
        forward = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, 0), 1.2f*dist, LayerMask.GetMask("Tilemap_Platform"));
        DebugLine(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, math.abs(face)*math.tan(angle*math.PI/180)), 1.3f*dist, forward_down);
        DebugLine(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, 0), 1.2f*dist, forward);

        face = transform.localScale.x;
   
    }
    
}
