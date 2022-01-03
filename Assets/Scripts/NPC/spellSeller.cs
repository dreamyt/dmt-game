using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSeller : MonoBehaviour
{
    // Start is called before the first frame update


    public bool isNPC = false;
    
    public int coin = 10;
    public GameObject enterDialog2;
    public GameObject enterDialog21;
    public GameObject enterDialog22;
    public GameObject enterDialog23;
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
            if (!CoinManager.Instance.isSpellBought1)
            {

            
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Debug.Log("111");

                    if (CoinManager.Instance.Coins >= coin)
                    {
                        Debug.Log("222");
                        CoinManager.Instance.LossCoins(coin);
                        character.GetComponent<CharacterSpell>().isLearnt0 = true;
                        CoinManager.Instance.isSpellBought1 = true;
                        character.GetComponent<CharacterSpell>().SwitchSpell1();
                        enterDialog22.SetActive(true);
                        enterDialog21.SetActive(false);
                        enterDialog2.SetActive(false);
                    }
                    else
                        enterDialog21.SetActive(true);
                        
                        enterDialog2.SetActive(false);

                }
            }
            else if (!CoinManager.Instance.isSpellBought2)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Debug.Log("111");



                    if (CoinManager.Instance.Coins >= coin)
                    {
                        Debug.Log("222");
                        CoinManager.Instance.LossCoins(coin);
                        character.GetComponent<CharacterSpell>().isLearnt1 = true;
                        CoinManager.Instance.isSpellBought2 = true;
                        character.GetComponent<CharacterSpell>().SwitchSpell2();
                        enterDialog22.SetActive(false);
                        enterDialog23.SetActive(true);
                    }
                    else
                    {
                        enterDialog21.SetActive(true);
                        enterDialog2.SetActive(false);
                    }

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
            Debug.Log("100");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNPC = false;
        enterDialog2.SetActive(false);
        enterDialog21.SetActive(false);
        enterDialog22.SetActive(false);
        enterDialog23.SetActive(false);
    }
}