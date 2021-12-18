using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBox : MonoBehaviour
{
    public Text Text1;

    void Update()
    {
        Text1.text = CoinManager.Instance.Coins.ToString();
    }
}
