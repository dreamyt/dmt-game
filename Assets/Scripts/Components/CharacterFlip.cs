using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : CharacterComponents
{
    [SerializeField] public bool Face;
    private bool m_FacingRight;
    public bool FacingRight;

    private void Awake()
    {
        FacingRight = Face;
        m_FacingRight = Face;
        //Debug.Log("characterFlip "+name+" "+FacingRight);
    }

    protected override void Start()
    {
        base.Start();
       
    }

    private void FixedUpdate()
    {
        if (GetComponent<CharacterMovement>().GetHorizontal() > 0 && !m_FacingRight)
        {
            
            Flip();
        }
        else if (GetComponent<CharacterMovement>().GetHorizontal() < 0 && m_FacingRight)
        {
            Debug.Log("flip to right "+name);
            Flip();
        }
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        FacingRight = m_FacingRight;
    }

    public void Flip()
    {
        //true -> false, false->true
        m_FacingRight = !m_FacingRight;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }
    
}
