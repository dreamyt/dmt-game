using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellReturnToPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float lifeTime = 2f;
    public LayerMask layer;
    public float damage;

    private SpellAttack spellAttack;

    private void Awake()
    {
        spellAttack = GetComponent<SpellAttack>();
    }
    // Returns this object to the pool
    private void Return()
    {
        if (spellAttack != null)
        {
            spellAttack.ResetSpellAttack();
        }
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Invoke(nameof(Return), lifeTime);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name+"before");
        Debug.Log(collision.gameObject.layer);
        Debug.Log(layer.value);
        if ((layer.value & 1<<collision.gameObject.layer) !=0)
        {
            Debug.Log(name);
            Debug.Log(collision.gameObject.layer);
            Debug.Log(layer.value);
            Return();
            
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
