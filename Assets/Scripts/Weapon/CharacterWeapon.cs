using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : CharacterComponents
{
    [Header("Weapon Settings")]
    [SerializeField] private Weapon weaponToUse;
    [SerializeField] private Transform weaponHolderPosition;


    // The reference of Weapon being used by player
    public Weapon CurrentWeapon { get; set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        EquipWeapon(weaponToUse, weaponHolderPosition);
    }

    /*
    // Just use the basis class (CharCompo) update function.
    void Update()
    {
        
    }
    */

    protected override void HandleInput()
    {
        if (Input.GetKey("j"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (CurrentWeapon == null)
        {
            return;
        }

        CurrentWeapon.TriggerShot();
    }

    public void EquipWeapon(Weapon weapon, Transform weaponPosition)
    {
        CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
        CurrentWeapon.transform.parent = weaponPosition;
        CurrentWeapon.SetOwner(character);
    }

}
