using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{

    [SerializeField] private int coinsToAdd;
    [SerializeField] public GameObject audio;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(audio, transform.position, transform.rotation);
            CoinManager.Instance.GetCoins(coinsToAdd);
            gameObject.SetActive(false);
        }
    }

}
