using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AIRaycast : MonoBehaviour
{
    private CharacterFlip flip;
    public LayerMask ground_layer;
    public LayerMask detect_attack_layer;
    public float face;
    public bool forward_down;
    public bool forward_top;
    public bool forward_bottom;
    public bool player_behind;
    public bool attack_range;
    [Header("Raycast offset settings")] 
    [SerializeField] private float offsetX=0;
    [SerializeField] private float offsetY=0;
    [SerializeField] private float offsetX_forwardTop=0;
    [SerializeField] private float offsetY_forwardTop=0;
    [SerializeField] private float offsetX_forwardDown=0;
    [SerializeField] private float offsetY_forwardDown=0;
    [SerializeField] private float angle = 0;
    [SerializeField] private float dist_forward_down = 1;
    [SerializeField] private float dist_forward;
    [SerializeField] private float dist_down;
    [SerializeField] private float detectRange = 1;
    [SerializeField] private float attackRange = 1;
    void Start()
    {
        flip = GetComponent<CharacterFlip>();
        //Debug.Log("AIRaycast "+name+" "+flip.FacingRight);
        if (flip.Face)
        {
            Debug.Log("facingright "+name);
            face = transform.localScale.x;
        }
        else
        {
            Debug.Log("facingleft" + name);
            //can't flip minotaur
            if (transform.localScale.x > 0)
            {
                face = -transform.localScale.x;
            }
            else
            {
                face = transform.localScale.x;
            }
        }
        Debug.Log(face);
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
       
        forward_down = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), 
            new Vector2(face, math.abs(face)*math.tan(angle*math.PI/180)), 1.3f*dist_forward_down, ground_layer);
        Debug.Log(name+ " AIRaycast: "+forward_down);
        forward_top = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX_forwardTop, transform.position.y+offsetY_forwardTop), 
            new Vector2(face, 0), 1.2f*dist_forward, ground_layer);
        forward_bottom = Physics2D.Raycast(new Vector2(transform.position.x+face*offsetX_forwardDown, transform.position.y+offsetY_forwardDown), 
            new Vector2(face, 0), 1.2f*dist_down, ground_layer);
        player_behind =
            Physics2D.Raycast(new Vector2(transform.position.x + offsetX, transform.position.y + offsetY),
                new Vector2(-face, 0), detectRange, detect_attack_layer);
        attack_range =
            Physics2D.Raycast(new Vector2(transform.position.x + offsetX, transform.position.y + offsetY),
                new Vector2(face, 0), attackRange, detect_attack_layer);
        
        DebugLine(new Vector2(transform.position.x+face*offsetX, transform.position.y+offsetY), new Vector2(face, math.abs(face)*math.tan(angle*math.PI/180)), 1.3f*dist_forward_down, forward_down);
        DebugLine(new Vector2(transform.position.x+face*offsetX_forwardTop, transform.position.y+offsetY_forwardTop), new Vector2(face, 0), 1.2f*dist_forward, forward_top);
        DebugLine(new Vector2(transform.position.x+face*offsetX_forwardDown, transform.position.y+offsetY_forwardDown), new Vector2(face, 0), 1.2f*dist_down, forward_bottom);
        DebugLine(new Vector2(transform.position.x + offsetX, transform.position.y + offsetY),
            new Vector2(-face, 0), detectRange, player_behind);
        DebugLine(new Vector2(transform.position.x + offsetX, transform.position.y + offsetY), new Vector2(face, 0),
            attackRange, attack_range);
    }
    
}
