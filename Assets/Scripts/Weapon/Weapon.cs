using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeBtwShots = 0.2f;

    [Header("Weapon")]
    [SerializeField] private bool useXXX = true;

    public Character WeaponOwner { get; set; }

    public void TriggerShot()
    {
        StartShooting();
    }

    // Activates our weapon in order to shoot
    private void StartShooting()
    {
        Debug.Log("Shooting");
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
