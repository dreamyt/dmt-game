using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float totalTime1 = 300;
    //private float totalTime2 = 100;
    private float intervalTime = 1;
    public GameObject panal;
    public Text Countdown1Text;
    //private Text Countdown2Text;
    // Start is called before the first frame update
    void Start()
    {
        Countdown1Text.text = string.Format("{0:D2}:{1:D2}",
            (int)totalTime1 / 60, (int)totalTime1 % 60);
        

        StartCoroutine(Countdown1());
    }

    

    private IEnumerator Countdown1()
    {
        while (totalTime1 > -1)
        {
            yield return new WaitForSeconds(1);
            if(totalTime1 != 0)
                totalTime1--;
            else
            {
                CoinManager.Instance.isTimeout = true;
            }
            Countdown1Text.text = string.Format("{0:D2}:{1:D2}",
            (int)totalTime1 / 60, (int)totalTime1 % 60);
            if (totalTime1 == 100)
                panal.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            totalTime1 = 300;
            CoinManager.Instance.isTimeout = false;
        }
    }
}
