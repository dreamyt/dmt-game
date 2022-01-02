using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellReturnToPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float lifeTime = 2f;

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

    private void OnDisable()
    {
        CancelInvoke();
    }
}
