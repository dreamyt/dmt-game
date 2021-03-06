using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Health enemyHealth;

    private float enemyCurrentHealth;
    private float enemyMaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            TakeDamage(col.GetComponent<ReturnToPool>().damage);
        }

        if (col.CompareTag("Spell"))
        {
            TakeDamage(col.GetComponent<SpellReturnToPool>().damage);
        }
    }

    private void TakeDamage(float damage)
    {
        enemyHealth.TakeDamage(damage);
    }

    private void UpdateHealth()
    {
        //health bar update
    }

    public void UpdateEnemyHealth(float currentHealth, float maxHealth)
    {
        enemyCurrentHealth = currentHealth;
        enemyMaxHealth = maxHealth;
    }
}
