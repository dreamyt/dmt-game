using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image magicBar;
    [SerializeField] private Image staminaBar;

    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerCurrentMagic;
    private float playerMaxMagic;
    private float playerCurrentStamina;
    private float playerMaxStamina;

    private void Update()
    {
        
        InternalUpdate();
        InternalMagicUpdate();
        InternalStaminaUpdate();
    }
    
    public void UpdateHealth(float health, float maxHealth)
    {
        playerCurrentHealth = health;
        playerMaxHealth = maxHealth;
    }

    public void UpdateMagic(float magic, float maxMagic)
    {
        playerCurrentMagic = magic;
        playerMaxMagic = maxMagic;
    }

    public void UpdateStamina(float stamina, float maxStamina)
    {
        playerCurrentStamina = stamina;
        playerMaxStamina = maxStamina;
    }

    private void InternalUpdate() 
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
        
        //healthBar.fillAmount = playerCurrentHealth / playerMaxHealth;
    }

    private void InternalMagicUpdate()
    {
        magicBar.fillAmount = Mathf.Lerp(magicBar.fillAmount, playerCurrentMagic / playerMaxMagic, 10f * Time.deltaTime);
    }

    private void InternalStaminaUpdate()
    {
        staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, playerCurrentStamina / playerMaxStamina, 10f * Time.deltaTime);
    }
}
 