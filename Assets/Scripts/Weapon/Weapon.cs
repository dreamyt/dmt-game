using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeBtwShots = 0.2f;

    [Header("Weapon")]
    [SerializeField] private bool useMagazine = false;
    [SerializeField] private float currentMagazine = 10.0f;
    [SerializeField] public bool canShoot = true;


    private float nextShotTime;
    public Character WeaponOwner { get; set; }
    public  ObjectPooler Pooler { get; set; }
    
    private CharacterController controller; 
    public AudioSource ShootAudio;
    protected virtual void Start()
    {
        Pooler = GetComponent<ObjectPooler>();
        canShoot = true;
        
    }

    protected virtual void Update()
    {
        WeaponCanShoot(); 
    }

    
    public void TriggerShot()
    {
        StartShooting();
    }

    // Activates our weapon in order to shoot
    protected virtual void StartShooting()
    {
        if (useMagazine)
        {
            if (currentMagazine > 0)
            {
                RequestShoot();
            }
        }
        else
        {
            RequestShoot();
        }
        
    }
    
    // The final part to request shoot
    protected virtual void RequestShoot()
    {
        if (canShoot)
        {
            ShootAudio.Play();
        }
    }

    // Controls the next time we can shoot
    protected virtual void WeaponCanShoot()
    {
        if (Time.time > nextShotTime)  //Actual time in the game GREATER THAN fire rate
        {
            canShoot = true;
            nextShotTime = Time.time + timeBtwShots;
        }
    }
    
    // Reference the owner of this Weapon
    public void SetOwner(Character owner)
    {
        WeaponOwner = owner;
        controller = WeaponOwner.GetComponent<CharacterController>();
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
