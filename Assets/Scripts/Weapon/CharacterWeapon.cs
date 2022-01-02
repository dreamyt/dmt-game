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
    //public Weapon SecondaryWeapon { get; set; }
    public Weapon SecondaryWeapon;

    public bool shootingAllowed = true;
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
        if (shootingAllowed)
        {
            if (Input.GetKey("j"))
            {
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && SecondaryWeapon != null)
        {
            Debug.Log("1111");
            EquipWeapon(weaponToUse , weaponHolderPosition);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && SecondaryWeapon != null)
        {
            Debug.Log("2222");
            EquipWeapon(SecondaryWeapon, weaponHolderPosition);
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
        if(CurrentWeapon!=null)
        {
            //Destroy(GameObject.Find("Pool"));
            Destroy(CurrentWeapon.gameObject);
            CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
            /*if (characterController.FacingRight)
            {
                CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
            }
            else if (!characterController.FacingRight)
            {
                Quaternion flip = Quaternion.Euler(0f, 180, 0);
                CurrentWeapon = Instantiate(weapon, weaponPosition.position, flip);
            }*/
        }
        else
        {
            CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
        }
        
        CurrentWeapon.transform.parent = weaponPosition;
        CurrentWeapon.SetOwner(character);
    }

    public void ShowWeapon()
    {
        CurrentWeapon.ShowWeapon();
    }

    public void RemoveWeapon()
    {
        CurrentWeapon.RemoveWeapon();
    }
}
