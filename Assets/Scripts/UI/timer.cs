using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float totalTime1 = 0;
    //private float totalTime2 = 100;
    private float intervalTime = 1;

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
            totalTime1++;
            Countdown1Text.text = string.Format("{0:D2}:{1:D2}",
            (int)totalTime1 / 60, (int)totalTime1 % 60);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}