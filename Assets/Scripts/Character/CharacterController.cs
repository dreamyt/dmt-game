using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 700f;  //jump force
    public bool canAirControl = false;  //whether we can control the player while in the air
    public LayerMask groundMask;    //determine which layer is ground
    public Transform m_GroundCheck; //component used to determine the ground
    public bool isGrounded = true;
    const float k_GroundedRadius = 0.2f; //the radius of a small circle used to detect the ground
    private bool m_Grounded = true;    //whether player is on the ground
    private bool m_FacingRight = true;  //whether the player is facing right
    public bool FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    const float m_NextGroundCheckLag = 0.1f; //After a short period of time after the jump, you can not jump again. A solution to prevent continuous jumping
    float m_NextGroundCheckTime=-1;    //You only can jump again after this period of time
    private Rigidbody2D m_Rigidbody2D;

    private Vector2 recoilMovement;

    public float move;
    public bool jump;
    private void Awake()
    {
        isGrounded = true;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //detect collision with the ground
        m_Grounded = false;
        if (Time.time > m_NextGroundCheckTime)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, groundMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                }
            }
        }
        isGrounded = m_Grounded;
        FacingRight = m_FacingRight;
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        //if player is on the ground or they can move in the air
        if (m_Grounded || canAirControl)
        {
            //variable move decides the x velocity
            m_Rigidbody2D.velocity = new Vector2(move, m_Rigidbody2D.velocity.y);

            //flip
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }

        }

        //press the jump key, player will jump if he's on the ground
        if (m_Grounded && jump)
        {
            m_Grounded = false;
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);

            //Add jump force
            m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            m_NextGroundCheckTime = Time.time + m_NextGroundCheckLag;
        }
    }

    public void SetMovement(float m, bool j)
    {
        this.move = m;
        this.jump = j;
    }
    private void Flip()
    {
        //true -> false, false->true
        m_FacingRight = !m_FacingRight;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }

    private void Recoil()
    {
        if (recoilMovement.magnitude > 0.1f)
        {
            m_Rigidbody2D.AddForce(recoilMovement);
        }
    }
    
}
