using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSeller : MonoBehaviour
{
    // Start is called before the first frame update


    public bool isNPC = false;
    
    public int coin = 10;

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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("111");



                if (CoinManager.Instance.Coins >= coin)
                {
                    Debug.Log("222");
                    CoinManager.Instance.LossCoins(coin);
                    character.GetComponent<CharacterSpell>().isLearnt0 = true;
                    CoinManager.Instance.isSpellBought2 = true;
                }


            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("111");



                if (CoinManager.Instance.Coins >= coin)
                {
                    Debug.Log("222");
                    CoinManager.Instance.LossCoins(coin);
                    character.GetComponent<CharacterSpell>().isLearnt1 = true;
                    CoinManager.Instance.isSpellBought1 = true;
                }


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("000");
            character = collision.gameObject.GetComponent<Character>();
            isNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNPC = false;
    }
}