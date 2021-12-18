using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 700f;  //jump force
    public bool canAirControl = false;  //whether we can control the player while in the air
    public LayerMask groundMask;    //determine which layer is ground
    public Transform m_GroundCheck; //component used to determine the ground
    public bool isGrounded;

    const float k_GroundedRadius = 0.2f; //the radius of a small circle used to detect the ground
    private bool m_Grounded;    //whether player is on the ground
    private bool m_FacingRight = true;  //whether the player is facing right
    public bool FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    const float m_NextGroundCheckLag = 0.1f; //After a short period of time after the jump, you can not jump again. A solution to prevent continuous jumping
    float m_NextGroundCheckTime;    //You only can jump again after this period of time
    private Rigidbody2D m_Rigidbody2D;

    static public float x_coordinate;

    
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_Grounded = false;
        x_coordinate = m_Rigidbody2D.position.x;
        //detect collision with the ground
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
    }

    public void Move(float move, bool jump)
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

    private void Flip()
    {
        //true -> false, false->true
        m_FacingRight = !m_FacingRight;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }

    private void Update()
    {
        isGrounded = m_Grounded;
        FacingRight = m_FacingRight;
        x_coordinate = m_Rigidbody2D.position.x;
    }

   
}
