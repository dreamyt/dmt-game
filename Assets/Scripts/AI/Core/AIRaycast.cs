using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AIRaycast : MonoBehaviour
{
    private CharacterFlip flip;
    public LayerMask layer;
    public float face;
    public bool forward_down;
    public bool forward_top;
    public bool forward_bottom;
    [Header("Raycast offset settings")] 
    [SerializeField] private float offsetX=0;
    [SerializeField] private float offsetY=0;
    [SerializeField] private float offsetX2=0;
    [SerializeField] private float offsetY2=0;
    [SerializeField] private float offsetX3=0;
    [SerializeField] private float offsetY3=0;

    [SerializeField] private float angle = 0;
    [SerializeField] private float dist_forward_down = 1;
    [SerializeField] private float dist_forward;
    void Start()
    {
        flip = GetComponent<CharacterFlip>();
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
       
        forward_down = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, math.abs(face)*math.tan(angle*math.PI/180)), 1.3f*dist_forward_down, layer);
        forward_top = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX2, transform.position.y+offsetY2), new Vector2(face, 0), 1.2f*dist_forward, layer);
        forward_bottom = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX3, transform.position.y+offsetY3), new Vector2(face, 0), 1.2f*dist_forward, layer);

        DebugLine(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, math.abs(face)*math.tan(angle*math.PI/180)), 1.3f*dist_forward_down, forward_down);
        DebugLine(new Vector2(transform.position.x+face*offsetX2, transform.position.y+offsetY2), new Vector2(face, 0), 1.2f*dist_forward, forward_top);
        DebugLine(new Vector2(transform.position.x+face*offsetX3, transform.position.y+offsetY3), new Vector2(face, 0), 1.2f*dist_forward, forward_bottom);
        face = transform.localScale.x;
   
    }
    
}
