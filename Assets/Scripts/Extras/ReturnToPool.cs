using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float lifeTime = 2f;

    public LayerMask layer;
    public float damage;
    private Projectile projectile;

    private void Start()
    {
        projectile = GetComponent<Projectile>();
    }
    // Returns this object to the pool
    private void Return()
    {
        if (projectile != null)
        {
            projectile.ResetProjectile();
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layer.value & 1<<collision.gameObject.layer) !=0)
        {
            Return();
        }
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
