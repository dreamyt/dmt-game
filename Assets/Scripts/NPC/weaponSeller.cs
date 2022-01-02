using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSeller : MonoBehaviour
{
    [SerializeField] private ItemData itemWeaponData;
    [SerializeField] public int coins = 30;
    bool isNPC;
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
                //collision.gameObject.GetComponent<CharacterWeapon>().SecondaryWeapon = itemWeaponData.WeaponToEquip;
                character.GetComponent<CharacterWeapon>().SecondaryWeapon = itemWeaponData.WeaponToEquip;

                if (CoinManager.Instance.Coins >= coins)
                {
                    Debug.Log("222");
                    CoinManager.Instance.LossCoins(coins);

                }


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("000");

            isNPC = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNPC = false;
    }
}
