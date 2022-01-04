using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CharacterWeapon : CharacterComponents
{
    [Header("Weapon Settings")]
    [SerializeField] private Weapon weaponToUse;
    [SerializeField] private Transform weaponHolderPosition;
    [SerializeField] private ItemData itemWeaponData;
    private float interval= 1;
    private bool isSecond = false;
    // The reference of Weapon being used by player
    public Weapon CurrentWeapon { get; set; }
    //public Weapon SecondaryWeapon { get; set; }
    public Weapon SecondaryWeapon;

    public bool shootingAllowed = true;
    
    public AudioSource ShootAudio;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        EquipWeapon(weaponToUse, weaponHolderPosition);
        if(CoinManager.Instance.isWeaponBought)
            SecondaryWeapon = itemWeaponData.WeaponToEquip;
    }

    
    protected override void Update()
    {
        base.Update();
        if (interval < 1)
            interval += Time.deltaTime;
    }
    

    protected override void HandleInput()
    {
        
        if (shootingAllowed)
        {
            if (Input.GetKey("j"))
            {
                
                
                if (isSecond)
                {

                    if (interval >= 1)
                    {
                        if (CoinManager.Instance.Coins > 0)
                        {
                            CoinManager.Instance.LossCoins(1);
                            if (CoinManager.Instance.Coins < 0)
                                CoinManager.Instance.Coins = 0;
                        }
                            
                        interval = 0;
                    }
                        
                    
                }
                if(CoinManager.Instance.Coins>0)
                    Shoot();
                
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && SecondaryWeapon != null)
        {
            EquipWeapon(weaponToUse , weaponHolderPosition);
            isSecond = false;
        }

        if (Input.GetKeyDown(KeyCode.I) && SecondaryWeapon != null)
        {
            EquipWeapon(SecondaryWeapon, weaponHolderPosition);
            isSecond = true;
        }
    }

    public void Shoot()
    {
        if (CurrentWeapon == null)
        {
            return;
        }

        ShootAudio.Play();
        CurrentWeapon.TriggerShot();
    }

    public void EquipWeapon(Weapon weapon, Transform weaponPosition)
    {
        if(CurrentWeapon!=null)
        {
            //Destroy(GameObject.Find("Pool"));
            Destroy(CurrentWeapon.gameObject);
            //CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
            if (GetComponent<CharacterFlip>().FacingRight)
            {
                CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
            }
            else if (!GetComponent<CharacterFlip>().FacingRight)
            {
                Quaternion flip = Quaternion.Euler(0f, 180, 0);
                CurrentWeapon = Instantiate(weapon, weaponPosition.position, flip);
            }
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
