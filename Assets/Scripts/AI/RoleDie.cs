using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleDie : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rigid;

    public bool death = false;
    //public GameObject prefabDeadFX;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public virtual void Die(Transform trans)
    {
        //Instantiate(prefabDeadFX, trans.position, Quaternion.identity);
        death = true;
        rigid.simulated = false;
        anim.SetBool("Death", true);
        Destroy(gameObject, 1.5f);
    }
}

