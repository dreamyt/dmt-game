using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSeller : MonoBehaviour
{
    [SerializeField] private ItemData itemWeaponData;
    [SerializeField] public int coins = 30;
    bool isNPC;
    bool isWeapon;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNPC)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("111");
                
                
                
                if (CoinManager.Instance.Coins >= coins)
                {
                    Debug.Log("222");
                    CoinManager.Instance.LossCoins(coins);
                    character.GetComponent<CharacterWeapon>().SecondaryWeapon = itemWeaponData.WeaponToEquip;
                    CoinManager.Instance.isWeaponBought = true;

                }


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            character = collision.gameObject.GetComponent<Character>();
            Debug.Log("000");

            isNPC = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNPC = false;
    }
}
