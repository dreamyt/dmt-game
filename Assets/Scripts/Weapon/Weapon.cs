using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeBtwShots = 0.2f;

    [Header("Weapon")]
    [SerializeField] private bool useXXX = true;
    [SerializeField] private bool canShoot = true;

    private Vector3 ProjectileGeneratePosition;
    private Vector3 projectileGeneratePosition;
    public Character WeaponOwner { get; set; }
    public  ObjectPooler Pooler { get; set; }

    public void Start()
    {
        Pooler = GetComponent<ObjectPooler>();
        
        projectileGeneratePosition = new Vector3(0f, 0f, 0f);
    }

    public void TriggerShot()
    {
        StartShooting();
    }

    // Activates our weapon in order to shoot
    private void StartShooting()
    {
        Debug.Log("Shooting");
        if (canShoot)
        {
            GameObject projectilePooled = Pooler.GetObjectFromPool();
            ProjectileGeneratePosition = transform.position + projectileGeneratePosition;
            projectilePooled.transform.position = ProjectileGeneratePosition;
            projectilePooled.SetActive(true);
        }
    }

    // Reference the owner of this Weapon
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
    }
    public void ShowWeapon()
    {
        gameObject.SetActive(true);
    }

    public void RemoveWeapon()
    {
        gameObject.SetActive(false);
    }

}
